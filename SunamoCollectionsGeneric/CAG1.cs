namespace SunamoCollectionsGeneric;

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

    public static bool IsAllTheSame<T>(T element, IList<T> list)
    {
        for (var i = 0; i < list.Count; i++)
            if (!EqualityComparer<T>.Default.Equals(list[i], element))
                return false;
        return true;
    }

    // More duplicates in the list result in more items in the output.
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

    public static List<T> GetDuplicities<T>(List<T> list)
    {
        return GetDuplicities(list, out _);
    }

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

    public static List<T> RemoveDuplicitiesList<T>(IList<T> list)
    {
        return RemoveDuplicitiesList(list, out _);
    }

    // Returns a list of unique items.
    // The out parameter contains every duplicate (possibly repeated).
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

    public static bool IsEqualToAnyElement<T>(T element, IList<T> list)
    {
        foreach (var item in list)
            if (EqualityComparer<T>.Default.Equals(element, item))
                return true;
        return false;
    }

    public static bool IsEqualToAnyElement<T>(T element, params T[] items)
    {
        return IsEqualToAnyElement(element, items.ToList());
    }
}
