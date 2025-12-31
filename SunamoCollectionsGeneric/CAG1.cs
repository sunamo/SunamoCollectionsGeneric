namespace SunamoCollectionsGeneric;

// EN: Variable names have been checked and replaced with self-descriptive names
// CZ: Názvy proměnných byly zkontrolovány a nahrazeny samopopisnými názvy
public partial class CAG
{
    public static int MaxElementsItemsInnerList<T>(List<List<T>> lists)
    {
        var max = 0;
        foreach (var item in lists)
            if (item.Count > max)
                max = item.Count;
        return max;
    }

    public static List<List<T>> TrimInnersToCount<T>(List<List<T>> lists, int targetCount)
    {
        for (var i = 0; i < lists.Count; i++)
            lists[i] = lists[i].Take(targetCount).ToList();
        return lists;
    }

    public static int LowestCount<T>(List<List<T>> lists)
    {
        var min = int.MaxValue;
        foreach (var item in lists)
            if (min > item.Count)
                min = item.Count;
        return min;
    }

    /// <summary>
    ///     ContainsAnyFromElement - Contains string elements of list. Return List
    ///     <string>
    ///         IsEqualToAnyElement - same as ContainsElement, only have switched elements. return bool
    ///         IsEqualToAllElement - takes two generic list. return bool
    ///         ContainsElement - at least one element must be equaled. generic. bool
    ///         IsSomethingTheSame - only for string. as List.Contains. bool
    ///         IsAllTheSame() - takes element and list.generic. bool
    ///         IndexesWithValue() - element and list.generic. return list
    ///         <int>
    ///             ReturnWhichContainsIndexes() - takes two list or element and list. return List<int>
    /// </summary>
    /// <typeparam name = "T"></typeparam>
    /// <param name = "ext"></param>
    /// <param name = "p1"></param>
    /// <returns></returns>
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
    public static L<T> GetDuplicities<T>(List<T> list, out List<T> alreadyProcessed)
    {
        alreadyProcessed = new List<T>(list.Count);
        var duplicated = new List<T>();
        foreach (var item in list)
            if (alreadyProcessed.Contains(item))
                duplicated.Add(item);
            else
                alreadyProcessed.Add(item);
        duplicated = duplicated.Distinct().ToList();
        return new L<T>();
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
    ///     Return equal ranges of in A1
    /// </summary>
    /// <param name = "list"></param>
    /// <param name = "searchPattern"></param>
    public static List<FromToCollectionsGenericShared> EqualRanges<T>(List<T> list, List<T> searchPattern)
    {
        var result = new List<FromToCollectionsGenericShared>();
        int? dx = null;
        var r_first = searchPattern[0];
        var startAt = 0;
        var valueToCompare = 0;
        for (var i = 0; i < list.Count; i++)
        {
            var currentElement = list[i];
            if (!dx.HasValue)
            {
                if (EqualityComparer<T>.Default.Equals(currentElement, r_first))
                {
                    dx = i + 1; // +2;
                    startAt = i;
                }
            }
            else
            {
                valueToCompare = dx.Value - startAt;
                if (searchPattern.Count > valueToCompare)
                {
                    if (EqualityComparer<T>.Default.Equals(currentElement, searchPattern[valueToCompare]))
                    {
                        dx++;
                    }
                    else
                    {
                        dx = null;
                        i--;
                    }
                }
                else
                {
                    var dx2 = (int)dx;
                    result.Add(new FromToCollectionsGenericShared(dx2 - searchPattern.Count + 1, dx2, FromToUseCollectionsGeneric.None));
                    dx = null;
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

    // <summary>
    /// direct edit
    /// Remove duplicities from A1
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="list"></param>
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
    ///     ContainsAnyFromElement - Contains string elements of list. Return List
    ///     <string>
    ///         IsEqualToAnyElement - same as ContainsElement, only have switched elements. return bool
    ///         IsEqualToAllElement - takes two generic list. return bool
    ///         ContainsElement - at least one element must be equaled. generic. bool
    ///         IsSomethingTheSame - only for string. as List.Contains. bool
    ///         IsAllTheSame() - takes element and list.generic. bool
    ///         IndexesWithValue() - element and list.generic. return list
    ///         <int>
    ///             ReturnWhichContainsIndexes() - takes two list or element and list. return List<int>
    /// </summary>
    /// <typeparam name = "T"></typeparam>
    /// <param name = "element"></param>
    /// <param name = "list"></param>
    public static bool IsEqualToAnyElement<T>(T element, IList<T> list)
    {
        foreach (var item in list)
            if (EqualityComparer<T>.Default.Equals(element, item))
                return true;
        return false;
    }

    /// <summary>
    ///     CA.ContainsAnyFromElement - Contains string elements of list. Return List
    ///     <string>
    ///         CAG.IsEqualToAnyElement - same as ContainsElement, only have switched elements. return bool
    ///         CA.IsEqualToAllElement - takes two generic list. return bool
    ///         CA.ContainsElement - at least one element must be equaled. generic. bool
    ///         CA.IsSomethingTheSame - only for string. as List.Contains. bool
    ///         CA.IsAllTheSame() - takes element and list.generic. bool
    ///         CA.IndexesWithValue() - element and list.generic. return list
    ///         <int>
    ///             CA.ReturnWhichContainsIndexes() - takes two list or element and list. return List<int>
    /// </summary>
    /// <typeparam name = "T"></typeparam>
    /// <param name = "element"></param>
    /// <param name = "items"></param>
    /// <returns></returns>
    public static bool IsEqualToAnyElement<T>(T element, params T[] items)
    {
        return IsEqualToAnyElement(element, items.ToList());
    }
}