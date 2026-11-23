namespace SunamoCollectionsGeneric;

public partial class CAG
{
    /// <summary>
    /// Max elements items inner list t.
    /// </summary>
    /// <typeparam name="T">The type T.</typeparam>
    /// <param name="lists">The lists.</param>
    /// <returns>The max elements items inner list t result.</returns>
    public static int MaxElementsItemsInnerList<T>(List<List<T>> lists)
    {
        var max = 0;
        foreach (var item in lists)
            if (item.Count > max)
                max = item.Count;
        return max;
    }

    /// <summary>
    /// Trim inners to count t.
    /// </summary>
    /// <typeparam name="T">The type T.</typeparam>
    /// <param name="lists">The lists.</param>
    /// <param name="targetCount">The target count.</param>
    /// <returns>The trim inners to count t result.</returns>
    public static List<List<T>> TrimInnersToCount<T>(List<List<T>> lists, int targetCount)
    {
        for (var i = 0; i < lists.Count; i++)
            lists[i] = lists[i].Take(targetCount).ToList();
        return lists;
    }

    /// <summary>
    /// Lowest count t.
    /// </summary>
    /// <typeparam name="T">The type T.</typeparam>
    /// <param name="lists">The lists.</param>
    /// <returns>The lowest count t result.</returns>
    public static int LowestCount<T>(List<List<T>> lists)
    {
        var min = int.MaxValue;
        foreach (var item in lists)
            if (min > item.Count)
                min = item.Count;
        return min;
    }

    /// <summary>
    /// Is all the same t.
    /// </summary>
    /// <typeparam name="T">The type T.</typeparam>
    /// <param name="element">The element.</param>
    /// <param name="list">The list.</param>
    /// <returns>The is all the same t result.</returns>
    public static bool IsAllTheSame<T>(T element, IList<T> list)
    {
        for (var i = 0; i < list.Count; i++)
            if (!EqualityComparer<T>.Default.Equals(list[i], element))
                return false;
        return true;
    }

    // More duplicates in the list result in more items in the output.
    /// <summary>
    /// Get duplicities t.
    /// </summary>
    /// <typeparam name="T">The type T.</typeparam>
    /// <param name="list">The list.</param>
    /// <param name="alreadyProcessed">The already processed.</param>
    /// <returns>The get duplicities t result.</returns>
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
    /// Get duplicities t.
    /// </summary>
    /// <typeparam name="T">The type T.</typeparam>
    /// <param name="list">The list.</param>
    /// <returns>The get duplicities t result.</returns>
    public static List<T> GetDuplicities<T>(List<T> list)
    {
        return GetDuplicities(list, out _);
    }

    /// <summary>
    /// Equal ranges t.
    /// </summary>
    /// <typeparam name="T">The type T.</typeparam>
    /// <param name="list">The list.</param>
    /// <param name="searchPattern">The search pattern.</param>
    /// <returns>The equal ranges t result.</returns>
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
    /// Remove duplicities list t.
    /// </summary>
    /// <typeparam name="T">The type T.</typeparam>
    /// <param name="list">The list.</param>
    /// <returns>The remove duplicities list t result.</returns>
    public static List<T> RemoveDuplicitiesList<T>(IList<T> list)
    {
        return RemoveDuplicitiesList(list, out _);
    }

    // Returns a list of unique items.
    // The out parameter contains every duplicate (possibly repeated).
    /// <summary>
    /// Remove duplicities list t.
    /// </summary>
    /// <typeparam name="T">The type T.</typeparam>
    /// <param name="list">The list.</param>
    /// <param name="foundDuplicates">The found duplicates.</param>
    /// <returns>The remove duplicities list t result.</returns>
    public static List<T> RemoveDuplicitiesList<T>(IList<T> list, out List<T> foundDuplicates)
    {
        foundDuplicates = new List<T>();
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
                foundDuplicates.Add(item);
            }
        }

        return uniqueItems;
    }

    /// <summary>
    /// Is equal to any element t.
    /// </summary>
    /// <typeparam name="T">The type T.</typeparam>
    /// <param name="element">The element.</param>
    /// <param name="list">The list.</param>
    /// <returns>The is equal to any element t result.</returns>
    public static bool IsEqualToAnyElement<T>(T element, IList<T> list)
    {
        foreach (var item in list)
            if (EqualityComparer<T>.Default.Equals(element, item))
                return true;
        return false;
    }

    /// <summary>
    /// Is equal to any element t.
    /// </summary>
    /// <typeparam name="T">The type T.</typeparam>
    /// <param name="element">The element.</param>
    /// <param name="items">The items.</param>
    /// <returns>The is equal to any element t result.</returns>
    public static bool IsEqualToAnyElement<T>(T element, params T[] items)
    {
        return IsEqualToAnyElement(element, items.ToList());
    }
}
