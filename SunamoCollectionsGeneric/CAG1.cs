namespace SunamoCollectionsGeneric;

/// <summary>
/// Collection helper class providing utility methods for working with generic collections (partial class continuation)
/// </summary>
public partial class CAG
{
    /// <summary>
    /// Finds the maximum number of elements among all inner lists
    /// </summary>
    /// <typeparam name="T">The type of elements</typeparam>
    /// <param name="lists">The list of lists to examine</param>
    /// <returns>The count of the largest inner list</returns>
    public static int MaxElementsItemsInnerList<T>(List<List<T>> lists)
    {
        var max = 0;
        foreach (var item in lists)
            if (item.Count > max)
                max = item.Count;
        return max;
    }

    /// <summary>
    /// Trims all inner lists to the specified count by taking only the first targetCount elements
    /// </summary>
    /// <typeparam name="T">The type of elements</typeparam>
    /// <param name="lists">The list of lists to trim</param>
    /// <param name="targetCount">The maximum number of elements to keep in each inner list</param>
    /// <returns>The modified list with trimmed inner lists</returns>
    public static List<List<T>> TrimInnersToCount<T>(List<List<T>> lists, int targetCount)
    {
        for (var i = 0; i < lists.Count; i++)
            lists[i] = lists[i].Take(targetCount).ToList();
        return lists;
    }

    /// <summary>
    /// Finds the lowest count among all inner lists
    /// </summary>
    /// <typeparam name="T">The type of elements</typeparam>
    /// <param name="lists">The list of lists to examine</param>
    /// <returns>The count of the smallest inner list</returns>
    public static int LowestCount<T>(List<List<T>> lists)
    {
        var min = int.MaxValue;
        foreach (var item in lists)
            if (min > item.Count)
                min = item.Count;
        return min;
    }

    /// <summary>
    /// Checks if all elements in the list are equal to the specified element
    /// </summary>
    /// <typeparam name = "T">The type of elements</typeparam>
    /// <param name = "element">The element to compare against</param>
    /// <param name = "list">The list to check</param>
    /// <returns>True if all elements are equal to the specified element, false otherwise</returns>
    public static bool IsAllTheSame<T>(T element, IList<T> list)
    {
        for (var i = 0; i < list.Count; i++)
            if (!EqualityComparer<T>.Default.Equals(list[i], element))
                return false;
        return true;
    }

    /// <summary>
    ///     Get every item once
    ///     A2 = more duplicities = more items
    /// </summary>
    /// <typeparam name = "T"></typeparam>
    /// <param name = "list"></param>
    /// <param name = "alreadyProcessed"></param>
    /// <returns></returns>
    public static List<T> GetDuplicities<T>(List<T> list, out List<T> alreadyProcessed)
    {
        alreadyProcessed = new List<T>(list.Count);
        var duplicated = new List<T>();
        foreach (var item in list)
            if (alreadyProcessed.Contains(item))
                duplicated.Add(item);
            else
                alreadyProcessed.Add(item);
        duplicated = duplicated.Distinct().ToList();
        return duplicated;
    }

    /// <summary>
    ///     Get every duplicated item once
    /// </summary>
    /// <typeparam name = "T"></typeparam>
    /// <param name = "list"></param>
    /// <returns></returns>
    public static List<T> GetDuplicities<T>(List<T> list)
    {
        List<T> alreadyProcessed;
        return GetDuplicities(list, out alreadyProcessed);
    }

    /// <summary>
    /// Returns equal ranges in the list that match the search pattern.
    /// </summary>
    /// <typeparam name="T">The type of elements.</typeparam>
    /// <param name="list">The list to search in.</param>
    /// <param name="searchPattern">The pattern to search for.</param>
    /// <returns>List of ranges where the pattern was found.</returns>
    public static List<FromToCollectionsGenericShared> EqualRanges<T>(List<T> list, List<T> searchPattern)
    {
        var result = new List<FromToCollectionsGenericShared>();
        int? patternMatchIndex = null;
        var firstPatternElement = searchPattern[0];
        var startAt = 0;
        var matchedCount = 0;
        for (var i = 0; i < list.Count; i++)
        {
            var currentElement = list[i];
            if (!patternMatchIndex.HasValue)
            {
                if (EqualityComparer<T>.Default.Equals(currentElement, firstPatternElement))
                {
                    patternMatchIndex = i + 1; // +2;
                    startAt = i;
                }
            }
            else
            {
                matchedCount = patternMatchIndex.Value - startAt;
                if (searchPattern.Count > matchedCount)
                {
                    if (EqualityComparer<T>.Default.Equals(currentElement, searchPattern[matchedCount]))
                    {
                        patternMatchIndex++;
                    }
                    else
                    {
                        patternMatchIndex = null;
                        i--;
                    }
                }
                else
                {
                    var endIndex = (int)patternMatchIndex;
                    result.Add(new FromToCollectionsGenericShared(endIndex - searchPattern.Count + 1, endIndex, FromToUseCollectionsGeneric.None));
                    patternMatchIndex = null;
                }
            }
        }

        foreach (var item in result)
        {
            item.From--;
            item.To--;
        }

        return result;
    }

    /// <summary>
    /// Removes duplicates from the list (direct edit)
    /// </summary>
    /// <typeparam name="T">The type of elements</typeparam>
    /// <param name="list">The list to remove duplicates from</param>
    /// <returns>List of unique items</returns>
    public static List<T> RemoveDuplicitiesList<T>(IList<T> list)
    {
        List<T> foundedDuplicities;
        return RemoveDuplicitiesList(list, out foundedDuplicities);
    }

    /// <summary>
    ///     direct edit
    ///     Remove duplicities from A1
    ///     In return value is from every one instance
    ///     In A2 is every duplicities (maybe the same more times)
    /// </summary>
    /// <typeparam name = "T"></typeparam>
    /// <param name = "list"></param>
    /// <param name = "foundedDuplicities"></param>
    public static List<T> RemoveDuplicitiesList<T>(IList<T> list, out List<T> foundedDuplicities)
    {
        foundedDuplicities = new List<T>();
        var uniqueItems = new List<T>();
        for (var i = list.Count - 1; i >= 0; i--)
        {
            var item = list[i];
            if (!uniqueItems.Contains(item))
            {
                uniqueItems.Add(item);
            }
            else
            {
                list.RemoveAt(i);
                foundedDuplicities.Add(item);
            }
        }

        return uniqueItems;
    }

    /// <summary>
    /// Checks if the specified element is equal to any element in the list
    /// </summary>
    /// <typeparam name = "T">The type of elements</typeparam>
    /// <param name = "element">The element to search for</param>
    /// <param name = "list">The list to search in</param>
    /// <returns>True if element is found in the list, false otherwise</returns>
    public static bool IsEqualToAnyElement<T>(T element, IList<T> list)
    {
        foreach (var item in list)
            if (EqualityComparer<T>.Default.Equals(element, item))
                return true;
        return false;
    }

    /// <summary>
    /// Checks if the specified element is equal to any of the provided items
    /// </summary>
    /// <typeparam name = "T">The type of elements</typeparam>
    /// <param name = "element">The element to search for</param>
    /// <param name = "items">The items to search in</param>
    /// <returns>True if element is found in items, false otherwise</returns>
    public static bool IsEqualToAnyElement<T>(T element, params T[] items)
    {
        return IsEqualToAnyElement(element, items.ToList());
    }
}