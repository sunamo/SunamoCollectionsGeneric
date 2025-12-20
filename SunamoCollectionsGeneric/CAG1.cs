// EN: Variable names have been checked and replaced with self-descriptive names
// CZ: Názvy proměnných byly zkontrolovány a nahrazeny samopopisnými názvy
namespace SunamoCollectionsGeneric;
public partial class CAG
{
    public static int MaxElementsItemsInnerList<T>(List<List<T>> exists)
    {
        var max = 0;
        foreach (var item in exists)
            if (item.Count > max)
                max = item.Count;
        return max;
    }

    public static List<List<T>> TrimInnersToCount<T>(List<List<T>> exists, int lowest)
    {
        for (var i = 0; i < exists.Count; i++)
            exists[i] = exists[i].Take(lowest).ToList();
        return exists;
    }

    public static int LowestCount<T>(List<List<T>> exists)
    {
        var min = int.MaxValue;
        foreach (var item in exists)
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
    public static bool IsAllTheSame<T>(T ext, IList<T> p1)
    {
        for (var i = 0; i < p1.Count; i++)
            if (!EqualityComparer<T>.Default.Equals(p1[i], ext))
                return false;
        return true;
    }

    /// <summary>
    ///     Get every item once
    ///     A2 = more duplicities = more items
    /// </summary>
    /// <typeparam name = "T"></typeparam>
    /// <param name = "clipboardL"></param>
    /// <param name = "alreadyProcessed"></param>
    /// <returns></returns>
    public static L<T> GetDuplicities<T>(List<T> clipboardL, out List<T> alreadyProcessed)
    {
        alreadyProcessed = new List<T>(clipboardL.Count);
        var duplicated = new List<T>();
        foreach (var item in clipboardL)
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
    /// <param name = "clipboardL"></param>
    /// <returns></returns>
    public static List<T> GetDuplicities<T>(List<T> clipboardL)
    {
        List<T> alreadyProcessed;
        return GetDuplicities(clipboardL, out alreadyProcessed);
    }

    /// <summary>
    ///     Return equal ranges of in A1
    /// </summary>
    /// <param name = "contentOneSpace"></param>
    /// <param name = "r"></param>
    public static List<FromToCollectionsGenericShared> EqualRanges<T>(List<T> contentOneSpace, List<T> r)
    {
        var result = new List<FromToCollectionsGenericShared>();
        int? dx = null;
        var r_first = r[0];
        var startAt = 0;
        var valueToCompare = 0;
        for (var i = 0; i < contentOneSpace.Count; i++)
        {
            var _contentOneSpace = contentOneSpace[i];
            if (!dx.HasValue)
            {
                if (EqualityComparer<T>.Default.Equals(_contentOneSpace, r_first))
                {
                    dx = i + 1; // +2;
                    startAt = i;
                }
            }
            else
            {
                valueToCompare = dx.Value - startAt;
                if (r.Count > valueToCompare)
                {
                    if (EqualityComparer<T>.Default.Equals(_contentOneSpace, r[valueToCompare]))
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
                    result.Add(new FromToCollectionsGenericShared(dx2 - r.Count + 1, dx2, FromToUseCollectionsGeneric.None));
                    dx = null;
                }
            }
        }

        foreach (var item in result)
        {
            item.from--;
            item.to--;
        }

        return result;
    }

    // <summary>
    /// direct edit
    /// Remove duplicities from A1
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="idKesek"></param>
    public static List<T> RemoveDuplicitiesList<T>(IList<T> idKesek)
    {
        List<T> foundedDuplicities;
        return RemoveDuplicitiesList(idKesek, out foundedDuplicities);
    }

    /// <summary>
    ///     direct edit
    ///     Remove duplicities from A1
    ///     In return value is from every one instance
    ///     In A2 is every duplicities (maybe the same more times)
    /// </summary>
    /// <typeparam name = "T"></typeparam>
    /// <param name = "idKesek"></param>
    /// <param name = "foundedDuplicities"></param>
    public static List<T> RemoveDuplicitiesList<T>(IList<T> idKesek, out List<T> foundedDuplicities)
    {
        foundedDuplicities = new List<T>();
        var h = new List<T>();
        for (var i = idKesek.Count - 1; i >= 0; i--)
        {
            var item = idKesek[i];
            if (!h.Contains(item))
            {
                h.Add(item);
            }
            else
            {
                idKesek.RemoveAt(i);
                foundedDuplicities.Add(item);
            }
        }

        return h;
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
    /// <param name = "p"></param>
    /// <param name = "list"></param>
    public static bool IsEqualToAnyElement<T>(T p, IList<T> list)
    {
        foreach (var item in list)
            if (EqualityComparer<T>.Default.Equals(p, item))
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
    /// <param name = "p"></param>
    /// <param name = "prvky"></param>
    /// <returns></returns>
    public static bool IsEqualToAnyElement<T>(T p, params T[] prvky)
    {
        return IsEqualToAnyElement(p, prvky.ToList());
    }
}