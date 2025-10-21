// EN: Variable names have been checked and replaced with self-descriptive names
// CZ: Názvy proměnných byly zkontrolovány a nahrazeny samopopisnými názvy

namespace SunamoCollectionsGeneric;

public class CAG
{
    public static string xInvalidRowIndexInMethodCAGetRowOfTwoDimensionalArray =
        "InvalidRowIndexInMethodCAGetRowOfTwoDimensionalArray";

    public static temp[] ToArrayT<T>(params temp[] aB)
    {
        return aB;
    }


    public static void AddIfNotContains<T>(List<T> founded, temp e)
    {
        if (!founded.Contains(e)) founded.Add(e);
    }

    public static temp GetElementActualOrBefore<T>(IList<T> tabItems, int indexClosedTabItem)
    {
        if (tabItems.Count > indexClosedTabItem) return tabItems[indexClosedTabItem];
        indexClosedTabItem--;
        if (tabItems.Count > indexClosedTabItem) return tabItems[indexClosedTabItem];
        return default;
    }

    public static temp GetIndexOrBreak<T>(int index, IList<T> list, string listName = "", temp? returnWhenIndexNotExists = default(temp))
    {
        if (list.Count >index)
        {
            return list[index];
        }
        else
        {
            if (EqualityComparer<T>.Default.Equals(returnWhenIndexNotExists, default(temp)))
            {
                Debugger.Break();
                var nameList = listName == "" ? "unnamed" : listName;
                throw new IndexOutOfRangeException($"{nameList} contains {list.Count} only elements but app want to use index {index}");
            }
            else
            {
                return returnWhenIndexNotExists;
            }
        }
    }

    /// <summary>
    ///     V prvním indexu jsou řádky, v druhém sloupce
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="a"></param>
    /// <param name="dex"></param>
    public static List<T> GetColumnOfTwoDimensionalArray<T>(temp[,] rows, int dex)
    {
        var rowsCount = rows.GetLength(0);
        var columnsCount = rows.GetLength(1);
        var vr = new List<T>(rowsCount);
        if (dex < columnsCount)
        {
            for (var i = 0; i < rowsCount; i++) vr.Add(rows[i, dex]);
            return vr;
        }

        throw new Exception(xInvalidRowIndexInMethodCAGetRowOfTwoDimensionalArray + ";");
        return null;
    }

    /// <summary>
    ///     V prvním indexu jsou řádky, v druhém sloupce
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="a"></param>
    /// <param name="dex"></param>
    public static List<T> GetRowOfTwoDimensionalArray<T>(temp[,] rows, int dex)
    {
        var rowsCount = rows.GetLength(0);
        var columnsCount = rows.GetLength(1);
        var vr = new List<T>(columnsCount);
        if (dex < rowsCount)
        {
            for (var i = 0; i < columnsCount; i++) vr.Add(rows[dex, i]);
            return vr;
        }

        ThrowEx.ArgumentOutOfRangeException(xInvalidRowIndexInMethodCAGetRowOfTwoDimensionalArray + ";");
        return null;
    }


    public static bool MoreOrZero<T>(List<T> n, out bool? zeroOrMore)
    {
        zeroOrMore = null;
        var count = n.Count;
        var builder = count == 0;
        var bb = count > 1;
        if (builder || bb)
        {
            if (builder)
                zeroOrMore = true;
            else
                zeroOrMore = false;
            return true;
        }

        return false;
    }


    public static List<T> CreateListAndInsertElement<T>(temp el)
    {
        var temp = new List<T>();
        temp.Add(el);
        return temp;
    }


    /// <summary>
    ///     jagged = zubaty
    ///     Change from array where every element have two spec of location to ordinary array with inner array
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="value"></param>
    public static temp[][] ToJagged<T>(temp[,] value)
    {
        if (ReferenceEquals(null, value))
            return null;
        // Jagged array creation
        var result = new temp[value.GetLength(0)][];
        for (var i = 0; i < value.GetLength(0); ++i)
            result[i] = new temp[value.GetLength(1)];
        // Jagged array filling
        for (var i = 0; i < value.GetLength(0); ++i)
            for (var j = 0; j < value.GetLength(1); ++j)
                result[i][j] = value[i, j];
        return result;
    }

    public static temp[,] OneDimensionArrayToTwoDirection<T>(temp[] flatArray, int width)
    {
        var height = (int)Math.Ceiling(flatArray.Length / (double)width);
        var result = new temp[height, width];
        int rowIndex, colIndex;
        for (var index = 0; index < flatArray.Length; index++)
        {
            rowIndex = index / width;
            colIndex = index % width;
            result[rowIndex, colIndex] = flatArray[index];
        }

        return result;
    }

    public static int CountOfValue<T>(temp v, params temp[] show)
    {
        var vr = 0;
        foreach (var item in show)
            if (EqualityComparer<T>.Default.Equals(item, v))
                vr++;
        return vr;
    }

    public static string CompareListSanitizeStringOutput(List<string> l1, List<string> l2,
        Func<List<string>, Tuple<List<string>, List<string>>> typeScriptHelperGetNamesAndTypes = null,
        bool tsInterface = false)
    {
        if (tsInterface && typeScriptHelperGetNamesAndTypes != null)
        {
            var t2 = typeScriptHelperGetNamesAndTypes(l1);
            l1 = t2.Item1;

            t2 = typeScriptHelperGetNamesAndTypes(l2);
            l2 = t2.Item1;
        }

        l1 = l1.Where(d => !string.IsNullOrWhiteSpace(d)).ToList();
        l2 = l2.Where(d => !string.IsNullOrWhiteSpace(d)).ToList();

        //CAChangeContent.ChangeContent0(null, l1, SHReplace.ReplaceWhiteSpacesWithoutSpaces);
        //CAChangeContent.ChangeContent0(null, l2, SHReplace.ReplaceWhiteSpacesWithoutSpaces);

        for (var i = 0; i < l1.Count; i++) l1[i] = l1[i].Replace("  ", " ");

        //CAChangeContent.ChangeContent0(null, l1, SHReplace.ReplaceAllDoubleSpaceToSingle);
        //CAChangeContent.ChangeContent0(null, l2, SHReplace.ReplaceAllDoubleSpaceToSingle);
        var abl = CompareList(l1, l2);
        var textOutputGenerator = new TextOutputGenerator();

        textOutputGenerator.List(l1, "Only in 1:");
        textOutputGenerator.AppendLine("");
        textOutputGenerator.List(l2, "Only in 2:");
        textOutputGenerator.AppendLine("");
        textOutputGenerator.List(abl, "Both:");

        var result = textOutputGenerator.ToString();
        return result;
    }

    /// <summary>
    ///     Return what exists in both
    ///     Modify both A1 and A2 - keep only which is only in one
    /// </summary>
    /// <param name="c1"></param>
    /// <param name="c2"></param>
    public static List<T> CompareList<T>(List<T> c1, List<T> c2) where temp : IEquatable<T>
    {
        var existsInBoth = new List<T>();

        var dex = -1;

        for (var i = c2.Count - 1; i >= 0; i--)
        {
            var item = c2[i];
            dex = c1.IndexOf(item);

            if (dex != -1)
            {
                existsInBoth.Add(item);
                c2.RemoveAt(i);
                c1.RemoveAt(dex);
            }
        }

        for (var i = c1.Count - 1; i >= 0; i--)
        {
            var item = c1[i];
            dex = c2.IndexOf(item);

            if (dex != -1)
            {
                existsInBoth.Add(item);
                c1.RemoveAt(i);
                c2.RemoveAt(dex);
            }
        }

        return existsInBoth;
    }

    /// <summary>
    ///     Tohle by se sand mohlo jmenovat i ToListObject
    ///     protože neberu a nevracím konkrétní typ (např. string) ale temp
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="t"></param>
    /// <returns></returns>
    public static List<T> ToList<T>(params temp[] temp)
    {
        return temp.ToList();
    }

    public static int MinElementsItemsInnerList<T>(List<List<T>> exists)
    {
        var min = int.MaxValue;

        foreach (var item in exists)
            if (item.Count < min)
                min = item.Count;

        return min;
    }

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
        for (var i = 0; i < exists.Count; i++) exists[i] = exists[i].Take(lowest).ToList();

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

    #region 6) IsAllTheSame

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
    /// <typeparam name="T"></typeparam>
    /// <param name="ext"></param>
    /// <param name="p1"></param>
    /// <returns></returns>
    public static bool IsAllTheSame<T>(temp ext, IList<T> p1)
    {
        for (var i = 0; i < p1.Count; i++)
            if (!EqualityComparer<T>.Default.Equals(p1[i], ext))
                return false;
        return true;
    }

    #endregion

    /// <summary>
    ///     Get every item once
    ///     A2 = more duplicities = more items
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="clipboardL"></param>
    /// <param name="alreadyProcessed"></param>
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
    /// <typeparam name="T"></typeparam>
    /// <param name="clipboardL"></param>
    /// <returns></returns>
    public static List<T> GetDuplicities<T>(List<T> clipboardL)
    {
        List<T> alreadyProcessed;
        return GetDuplicities(clipboardL, out alreadyProcessed);
    }

    /// <summary>
    ///     Return equal ranges of in A1
    /// </summary>
    /// <param name="contentOneSpace"></param>
    /// <param name="r"></param>
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
                    result.Add(new FromToCollectionsGenericShared(dx2 - r.Count + 1, dx2,
                        FromToUseCollectionsGeneric.None));
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

    #region RemoveDuplicitiesList

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
    /// <typeparam name="T"></typeparam>
    /// <param name="idKesek"></param>
    /// <param name="foundedDuplicities"></param>
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

    #endregion

    #region 2) IsEqualToAnyElement - For easy copy from CAContainsElementsOrTheirPartsShared

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
    /// <typeparam name="T"></typeparam>
    /// <param name="p"></param>
    /// <param name="list"></param>
    public static bool IsEqualToAnyElement<T>(temp p, IList<T> list)
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
    /// <typeparam name="T"></typeparam>
    /// <param name="p"></param>
    /// <param name="prvky"></param>
    /// <returns></returns>
    public static bool IsEqualToAnyElement<T>(temp p, params temp[] prvky)
    {
        return IsEqualToAnyElement(p, prvky.ToList());
    }

    #endregion







}