namespace SunamoCollectionsGeneric;

/// <summary>
/// Represents the CAG type.
/// </summary>
public partial class CAG
{
    /// <summary>
    /// The x invalid row index in method CA get row of two dimensional array constant.
    /// </summary>
    public const string XInvalidRowIndexInMethodCAGetRowOfTwoDimensionalArray = "InvalidRowIndexInMethodCAGetRowOfTwoDimensionalArray";

    /// <summary>
    /// To array t t.
    /// </summary>
    /// <typeparam name="T">The type T.</typeparam>
    /// <param name="array">The array.</param>
    /// <returns>The to array t t result.</returns>
    public static T[] ToArrayT<T>(params T[] array)
    {
        return array;
    }

    /// <summary>
    /// Add if not contains t.
    /// </summary>
    /// <typeparam name="T">The type T.</typeparam>
    /// <param name="list">The list.</param>
    /// <param name="element">The element.</param>
    /// <returns>The add if not contains t result.</returns>
    public static void AddIfNotContains<T>(List<T> list, T element)
    {
        if (!list.Contains(element))
            list.Add(element);
    }

    /// <summary>
    /// Initializes a new instance of the get element actual or before t class.
    /// </summary>
    /// <param name="element">The element.</param>
    public static T GetElementActualOrBefore<T>(IList<T> list, int index)
    {
        if (list.Count > index)
            return list[index];
        index--;
        if (list.Count > index)
            return list[index];
        return default!;
    }

    /// <summary>
    /// Get index or break t.
    /// </summary>
    /// <typeparam name="T">The type T.</typeparam>
    /// <param name="index">The index.</param>
    /// <param name="list">The list.</param>
    /// <param name="listName">The list name.</param>
    /// <param name="returnWhenIndexNotExists">The return when index not exists.</param>
    /// <returns>The get index or break t result.</returns>
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
                return returnWhenIndexNotExists!;
            }
        }
    }

    // In the first index are rows, in the second are columns.
    /// <summary>
    /// Get column of two dimensional array t.
    /// </summary>
    /// <typeparam name="T">The type T.</typeparam>
    /// <param name="rows">The rows.</param>
    /// <param name="columnIndex">The column index.</param>
    /// <returns>The get column of two dimensional array t result.</returns>
    public static List<T> GetColumnOfTwoDimensionalArray<T>(T[, ] rows, int columnIndex)
    {
        var rowsCount = rows.GetLength(0);
        var columnsCount = rows.GetLength(1);
        var result = new List<T>(rowsCount);
        if (columnIndex < columnsCount)
        {
            for (var i = 0; i < rowsCount; i++)
                result.Add(rows[i, columnIndex]);
            return result;
        }

        throw new Exception(XInvalidRowIndexInMethodCAGetRowOfTwoDimensionalArray + ";");
    }

    // In the first index are rows, in the second are columns.
    /// <summary>
    /// Get row of two dimensional array t.
    /// </summary>
    /// <typeparam name="T">The type T.</typeparam>
    /// <param name="rows">The rows.</param>
    /// <param name="rowIndex">The row index.</param>
    /// <returns>The get row of two dimensional array t result.</returns>
    public static List<T> GetRowOfTwoDimensionalArray<T>(T[, ] rows, int rowIndex)
    {
        var rowsCount = rows.GetLength(0);
        var columnsCount = rows.GetLength(1);
        var result = new List<T>(columnsCount);
        if (rowIndex < rowsCount)
        {
            for (var i = 0; i < columnsCount; i++)
                result.Add(rows[rowIndex, i]);
            return result;
        }

        ThrowEx.ArgumentOutOfRangeException(XInvalidRowIndexInMethodCAGetRowOfTwoDimensionalArray + ";");
        return null!;
    }

    /// <summary>
    /// More or zero t.
    /// </summary>
    /// <typeparam name="T">The type T.</typeparam>
    /// <param name="list">The list.</param>
    /// <param name="zeroOrMore">The zero or more.</param>
    /// <returns>The more or zero t result.</returns>
    public static bool MoreOrZero<T>(List<T> list, out bool? zeroOrMore)
    {
        zeroOrMore = null;
        var count = list.Count;
        var isEmpty = count == 0;
        var hasMultiple = count > 1;
        if (isEmpty || hasMultiple)
        {
            if (isEmpty)
                zeroOrMore = true;
            else
                zeroOrMore = false;
            return true;
        }

        return false;
    }

    /// <summary>
    /// Create list and insert element t.
    /// </summary>
    /// <typeparam name="T">The type T.</typeparam>
    /// <param name="element">The element.</param>
    /// <returns>The create list and insert element t result.</returns>
    public static List<T> CreateListAndInsertElement<T>(T element)
    {
        var list = new List<T>();
        list.Add(element);
        return list;
    }

    // Changes from an array where every element has two specifications of location to an ordinary array with inner arrays.
    /// <summary>
    /// To jagged t.
    /// </summary>
    /// <typeparam name="T">The type T.</typeparam>
    /// <param name="array">The array.</param>
    /// <returns>The to jagged t result.</returns>
    public static T[][] ToJagged<T>(T[, ] array)
    {
        if (array is null)
            return null!;
        // Jagged array creation
        var result = new T[array.GetLength(0)][];
        for (var i = 0; i < array.GetLength(0); ++i)
            result[i] = new T[array.GetLength(1)];
        // Jagged array filling
        for (var i = 0; i < array.GetLength(0); ++i)
            for (var j = 0; j < array.GetLength(1); ++j)
                result[i][j] = array[i, j];
        return result;
    }

    /// <summary>
    /// One dimension array to two direction t.
    /// </summary>
    /// <typeparam name="T">The type T.</typeparam>
    /// <param name="flatArray">The flat array.</param>
    /// <param name="width">The width.</param>
    /// <returns>The one dimension array to two direction t result.</returns>
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

    /// <summary>
    /// Count of value t.
    /// </summary>
    /// <typeparam name="T">The type T.</typeparam>
    /// <param name="value">The value.</param>
    /// <param name="items">The items.</param>
    /// <returns>The count of value t result.</returns>
    public static int CountOfValue<T>(T value, params T[] items)
    {
        var count = 0;
        foreach (var item in items)
            if (EqualityComparer<T>.Default.Equals(item, value))
                count++;
        return count;
    }

    /// <summary>
    /// Compare list sanitize string output.
    /// </summary>
    /// <param name="firstList">The first list.</param>
    /// <param name="secondList">The second list.</param>
    /// <param name="typeScriptHelperGetNamesAndTypes">The type script helper get names and types.</param>
    /// <param name="isTsInterface">The is ts interface.</param>
    /// <returns>The compare list sanitize string output result.</returns>
    public static string CompareListSanitizeStringOutput(List<string> firstList, List<string> secondList, Func<List<string>, Tuple<List<string>, List<string>>>? typeScriptHelperGetNamesAndTypes = null, bool isTsInterface = false)
    {
        if (isTsInterface && typeScriptHelperGetNamesAndTypes != null)
        {
            var tupleResult = typeScriptHelperGetNamesAndTypes(firstList);
            firstList = tupleResult.Item1;
            tupleResult = typeScriptHelperGetNamesAndTypes(secondList);
            secondList = tupleResult.Item1;
        }

        firstList = firstList.Where(text => !string.IsNullOrWhiteSpace(text)).ToList();
        secondList = secondList.Where(text => !string.IsNullOrWhiteSpace(text)).ToList();
        for (var i = 0; i < firstList.Count; i++)
            firstList[i] = firstList[i].Replace("  ", " ");
        var existsInBoth = CompareList(firstList, secondList);
        var textOutputGenerator = new TextOutputGenerator();
        textOutputGenerator.List(firstList, "Only in 1:");
        textOutputGenerator.AppendLine("");
        textOutputGenerator.List(secondList, "Only in 2:");
        textOutputGenerator.AppendLine("");
        textOutputGenerator.List(existsInBoth, "Both:");
        var result = textOutputGenerator.ToString();
        return result;
    }

    /// <summary>
    /// Compare list t.
    /// </summary>
    /// <typeparam name="T">The type T.</typeparam>
    /// <param name="firstList">The first list.</param>
    /// <param name="secondList">The second list.</param>
    /// <returns>The compare list t result.</returns>
    public static List<T> CompareList<T>(List<T> firstList, List<T> secondList)
        where T : IEquatable<T>
    {
        var existsInBoth = new List<T>();
        var index = -1;
        for (var i = secondList.Count - 1; i >= 0; i--)
        {
            var item = secondList[i];
            index = firstList.IndexOf(item);
            if (index != -1)
            {
                existsInBoth.Add(item);
                secondList.RemoveAt(i);
                firstList.RemoveAt(index);
            }
        }

        for (var i = firstList.Count - 1; i >= 0; i--)
        {
            var item = firstList[i];
            index = secondList.IndexOf(item);
            if (index != -1)
            {
                existsInBoth.Add(item);
                firstList.RemoveAt(i);
                secondList.RemoveAt(index);
            }
        }

        return existsInBoth;
    }

    // This could also be named ToListObject because it doesn't take or return a specific type (e.g., string) but a generic type.
    /// <summary>
    /// To list t.
    /// </summary>
    /// <param name="e.g.">The e g.</param>
    /// <param name="string">The string.</param>
    /// <returns>The to list t result.</returns>
    public static List<T> ToList<T>(params T[] array)
    {
        return array.ToList();
    }

    /// <summary>
    /// Min elements items inner list t.
    /// </summary>
    /// <returns>The min elements items inner list t result.</returns>
    public static int MinElementsItemsInnerList<T>(List<List<T>> lists)
    {
        var min = int.MaxValue;
        foreach (var item in lists)
            if (item.Count < min)
                min = item.Count;
        return min;
    }
}
