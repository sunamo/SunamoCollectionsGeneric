namespace SunamoCollectionsGeneric;

// EN: Variable names have been checked and replaced with self-descriptive names
// CZ: Názvy proměnných byly zkontrolovány a nahrazeny samopopisnými názvy
public partial class CAG
{
    public static string xInvalidRowIndexInMethodCAGetRowOfTwoDimensionalArray = "InvalidRowIndexInMethodCAGetRowOfTwoDimensionalArray";
    public static T[] ToArrayT<T>(params T[] aB)
    {
        return aB;
    }

    public static void AddIfNotContains<T>(List<T> founded, T e)
    {
        if (!founded.Contains(e))
            founded.Add(e);
    }

    public static T GetElementActualOrBefore<T>(IList<T> tabItems, int indexClosedTabItem)
    {
        if (tabItems.Count > indexClosedTabItem)
            return tabItems[indexClosedTabItem];
        indexClosedTabItem--;
        if (tabItems.Count > indexClosedTabItem)
            return tabItems[indexClosedTabItem];
        return default;
    }

    public static T GetIndexOrBreak<T>(int index, IList<T> list, string listName = "", T? returnWhenIndexNotExists = default(T))
    {
        if (list.Count > index)
        {
            return list[index];
        }
        else
        {
            if (EqualityComparer<T>.Default.Equals(returnWhenIndexNotExists, default(T)))
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
    /// <typeparam name = "T"></typeparam>
    /// <param name = "a"></param>
    /// <param name = "dex"></param>
    public static List<T> GetColumnOfTwoDimensionalArray<T>(T[, ] rows, int dex)
    {
        var rowsCount = rows.GetLength(0);
        var columnsCount = rows.GetLength(1);
        var vr = new List<T>(rowsCount);
        if (dex < columnsCount)
        {
            for (var i = 0; i < rowsCount; i++)
                vr.Add(rows[i, dex]);
            return vr;
        }

        throw new Exception(xInvalidRowIndexInMethodCAGetRowOfTwoDimensionalArray + ";");
        return null;
    }

    /// <summary>
    ///     V prvním indexu jsou řádky, v druhém sloupce
    /// </summary>
    /// <typeparam name = "T"></typeparam>
    /// <param name = "a"></param>
    /// <param name = "dex"></param>
    public static List<T> GetRowOfTwoDimensionalArray<T>(T[, ] rows, int dex)
    {
        var rowsCount = rows.GetLength(0);
        var columnsCount = rows.GetLength(1);
        var vr = new List<T>(columnsCount);
        if (dex < rowsCount)
        {
            for (var i = 0; i < columnsCount; i++)
                vr.Add(rows[dex, i]);
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

    public static List<T> CreateListAndInsertElement<T>(T el)
    {
        var list = new List<T>();
        list.Add(el);
        return list;
    }

    /// <summary>
    ///     jagged = zubaty
    ///     Change from array where every element have two spec of location to ordinary array with inner array
    /// </summary>
    /// <typeparam name = "T"></typeparam>
    /// <param name = "value"></param>
    public static T[][] ToJagged<T>(T[, ] value)
    {
        if (ReferenceEquals(null, value))
            return null;
        // Jagged array creation
        var result = new T[value.GetLength(0)][];
        for (var i = 0; i < value.GetLength(0); ++i)
            result[i] = new T[value.GetLength(1)];
        // Jagged array filling
        for (var i = 0; i < value.GetLength(0); ++i)
            for (var j = 0; j < value.GetLength(1); ++j)
                result[i][j] = value[i, j];
        return result;
    }

    public static T[, ] OneDimensionArrayToTwoDirection<T>(T[] flatArray, int width)
    {
        var height = (int)Math.Ceiling(flatArray.Length / (double)width);
        var result = new T[height, width];
        int rowIndex, colIndex;
        for (var index = 0; index < flatArray.Length; index++)
        {
            rowIndex = index / width;
            colIndex = index % width;
            result[rowIndex, colIndex] = flatArray[index];
        }

        return result;
    }

    public static int CountOfValue<T>(T v, params T[] show)
    {
        var vr = 0;
        foreach (var item in show)
            if (EqualityComparer<T>.Default.Equals(item, v))
                vr++;
        return vr;
    }

    public static string CompareListSanitizeStringOutput(List<string> l1, List<string> l2, Func<List<string>, Tuple<List<string>, List<string>>> typeScriptHelperGetNamesAndTypes = null, bool tsInterface = false)
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
        for (var i = 0; i < l1.Count; i++)
            l1[i] = l1[i].Replace("  ", " ");
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
    /// <param name = "c1"></param>
    /// <param name = "c2"></param>
    public static List<T> CompareList<T>(List<T> c1, List<T> c2)
        where T : IEquatable<T>
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
    /// <typeparam name = "T"></typeparam>
    /// <param name = "t"></param>
    /// <returns></returns>
    public static List<T> ToList<T>(params T[] items)
    {
        return items.ToList();
    }

    public static int MinElementsItemsInnerList<T>(List<List<T>> exists)
    {
        var min = int.MaxValue;
        foreach (var item in exists)
            if (item.Count < min)
                min = item.Count;
        return min;
    }
}