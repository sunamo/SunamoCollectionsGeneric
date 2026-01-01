namespace SunamoCollectionsGeneric;

/// <summary>
/// Collection helper class providing utility methods for working with generic collections
/// </summary>
public partial class CAG
{
    /// <summary>
    /// Error message for invalid row index in GetRowOfTwoDimensionalArray method
    /// </summary>
    public static string XInvalidRowIndexInMethodCAGetRowOfTwoDimensionalArray = "InvalidRowIndexInMethodCAGetRowOfTwoDimensionalArray";

    /// <summary>
    /// Converts variable arguments to an array
    /// </summary>
    /// <typeparam name="T">The type of elements</typeparam>
    /// <param name="items">The items to convert to an array</param>
    /// <returns>An array containing the provided items</returns>
    public static T[] ToArrayT<T>(params T[] items)
    {
        return items;
    }

    /// <summary>
    /// Adds an element to the list only if it doesn't already contain it
    /// </summary>
    /// <typeparam name="T">The type of elements</typeparam>
    /// <param name="list">The list to add to</param>
    /// <param name="element">The element to add</param>
    public static void AddIfNotContains<T>(List<T> list, T element)
    {
        if (!list.Contains(element))
            list.Add(element);
    }

    /// <summary>
    /// Gets the element at the specified index, or the element before it if index is out of bounds
    /// </summary>
    /// <typeparam name="T">The type of elements</typeparam>
    /// <param name="items">The list to get element from</param>
    /// <param name="index">The index to retrieve</param>
    /// <returns>The element at index or the previous element, or default if not found</returns>
    public static T GetElementActualOrBefore<T>(IList<T> items, int index)
    {
        if (items.Count > index)
            return items[index];
        index--;
        if (items.Count > index)
            return items[index];
        return default;
    }

    /// <summary>
    /// Gets the element at the specified index, breaking into debugger or throwing exception if index is out of bounds
    /// </summary>
    /// <typeparam name="T">The type of elements</typeparam>
    /// <param name="index">The index to retrieve</param>
    /// <param name="list">The list to get element from</param>
    /// <param name="listName">Optional name of the list for error messages</param>
    /// <param name="returnWhenIndexNotExists">Optional value to return instead of throwing exception</param>
    /// <returns>The element at the specified index</returns>
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
    /// In the first index are rows, in the second are columns.
    /// </summary>
    /// <typeparam name="T">The type of elements in the array.</typeparam>
    /// <param name="rows">The two-dimensional array.</param>
    /// <param name="columnIndex">The index of the column to extract.</param>
    /// <returns>A list containing all elements from the specified column.</returns>
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
        return null;
    }

    /// <summary>
    /// In the first index are rows, in the second are columns.
    /// </summary>
    /// <typeparam name="T">The type of elements in the array.</typeparam>
    /// <param name="rows">The two-dimensional array.</param>
    /// <param name="rowIndex">The index of the row to extract.</param>
    /// <returns>A list containing all elements from the specified row.</returns>
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
        return null;
    }

    /// <summary>
    /// Checks if the list has zero or more than one element
    /// </summary>
    /// <typeparam name="T">The type of elements</typeparam>
    /// <param name="list">The list to check</param>
    /// <param name="zeroOrMore">True if list is empty, false if list has more than one element, null if list has exactly one element</param>
    /// <returns>True if list is empty or has more than one element, false if list has exactly one element</returns>
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
    /// Creates a new list and inserts the specified element into it
    /// </summary>
    /// <typeparam name="T">The type of element</typeparam>
    /// <param name="element">The element to insert</param>
    /// <returns>A list containing the single element</returns>
    public static List<T> CreateListAndInsertElement<T>(T element)
    {
        var list = new List<T>();
        list.Add(element);
        return list;
    }

    /// <summary>
    /// Converts a two-dimensional array to a jagged array (array of arrays).
    /// Changes from an array where every element has two specifications of location to an ordinary array with inner arrays.
    /// </summary>
    /// <typeparam name="T">The type of elements in the array.</typeparam>
    /// <param name="value">The two-dimensional array to convert.</param>
    /// <returns>A jagged array representation of the input.</returns>
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

    /// <summary>
    /// Converts a one-dimensional array to a two-dimensional array with the specified width
    /// </summary>
    /// <typeparam name="T">The type of elements</typeparam>
    /// <param name="flatArray">The one-dimensional array to convert</param>
    /// <param name="width">The width of the resulting two-dimensional array</param>
    /// <returns>A two-dimensional array</returns>
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
    /// Counts how many times a specific value appears in the provided items
    /// </summary>
    /// <typeparam name="T">The type of elements</typeparam>
    /// <param name="value">The value to count</param>
    /// <param name="items">The items to search in</param>
    /// <returns>The number of occurrences of the value</returns>
    public static int CountOfValue<T>(T value, params T[] items)
    {
        var count = 0;
        foreach (var item in items)
            if (EqualityComparer<T>.Default.Equals(item, value))
                count++;
        return count;
    }

    /// <summary>
    /// Compares two lists and returns a formatted string showing differences and common elements
    /// </summary>
    /// <param name="firstList">The first list to compare</param>
    /// <param name="secondList">The second list to compare</param>
    /// <param name="typeScriptHelperGetNamesAndTypes">Optional TypeScript helper function for parsing interfaces</param>
    /// <param name="isTsInterface">Whether the lists contain TypeScript interface definitions</param>
    /// <returns>A formatted string showing elements only in first list, only in second list, and in both</returns>
    public static string CompareListSanitizeStringOutput(List<string> firstList, List<string> secondList, Func<List<string>, Tuple<List<string>, List<string>>> typeScriptHelperGetNamesAndTypes = null, bool isTsInterface = false)
    {
        if (isTsInterface && typeScriptHelperGetNamesAndTypes != null)
        {
            var tupleResult = typeScriptHelperGetNamesAndTypes(firstList);
            firstList = tupleResult.Item1;
            tupleResult = typeScriptHelperGetNamesAndTypes(secondList);
            secondList = tupleResult.Item1;
        }

        firstList = firstList.Where(d => !string.IsNullOrWhiteSpace(d)).ToList();
        secondList = secondList.Where(d => !string.IsNullOrWhiteSpace(d)).ToList();
        //CAChangeContent.ChangeContent0(null, firstList, SHReplace.ReplaceWhiteSpacesWithoutSpaces);
        //CAChangeContent.ChangeContent0(null, secondList, SHReplace.ReplaceWhiteSpacesWithoutSpaces);
        for (var i = 0; i < firstList.Count; i++)
            firstList[i] = firstList[i].Replace("  ", " ");
        //CAChangeContent.ChangeContent0(null, firstList, SHReplace.ReplaceAllDoubleSpaceToSingle);
        //CAChangeContent.ChangeContent0(null, secondList, SHReplace.ReplaceAllDoubleSpaceToSingle);
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
    ///     Return what exists in both
    ///     Modify both A1 and A2 - keep only which is only in one
    /// </summary>
    /// <param name = "firstList"></param>
    /// <param name = "secondList"></param>
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

    /// <summary>
    /// Converts a variable number of parameters into a list.
    /// This could also be named ToListObject because it doesn't take or return a specific type (e.g., string) but a generic type.
    /// </summary>
    /// <typeparam name="T">The type of elements.</typeparam>
    /// <param name="items">The items to convert to a list.</param>
    /// <returns>A list containing the provided items.</returns>
    public static List<T> ToList<T>(params T[] items)
    {
        return items.ToList();
    }

    /// <summary>
    /// Finds the minimum number of elements among all inner lists
    /// </summary>
    /// <typeparam name="T">The type of elements</typeparam>
    /// <param name="lists">The list of lists to examine</param>
    /// <returns>The count of the smallest inner list</returns>
    public static int MinElementsItemsInnerList<T>(List<List<T>> lists)
    {
        var min = int.MaxValue;
        foreach (var item in lists)
            if (item.Count < min)
                min = item.Count;
        return min;
    }
}