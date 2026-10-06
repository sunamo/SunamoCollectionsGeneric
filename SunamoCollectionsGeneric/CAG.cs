namespace SunamoCollectionsGeneric;

public partial class CAG
{
    public const string XInvalidRowIndexInMethodCAGetRowOfTwoDimensionalArray = "InvalidRowIndexInMethodCAGetRowOfTwoDimensionalArray";

    public static T[] ToArrayT<T>(params T[] array)
    {
        return array;
    }

    public static void AddIfNotContains<T>(List<T> list, T element)
    {
        if (!list.Contains(element))
            list.Add(element);
    }

    public static T GetElementActualOrBefore<T>(IList<T> list, int index)
    {
        if (list.Count > index)
            return list[index];
        index--;
        if (list.Count > index)
            return list[index];
        return default!;
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
                return returnWhenIndexNotExists!;
            }
        }
    }

    // In the first index are rows, in the second are columns.
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

    public static List<T> CreateListAndInsertElement<T>(T element)
    {
        var list = new List<T>();
        list.Add(element);
        return list;
    }

    // Changes from an array where every element has two specifications of location to an ordinary array with inner arrays.
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

    public static int CountOfValue<T>(T value, params T[] items)
    {
        var count = 0;
        foreach (var item in items)
            if (EqualityComparer<T>.Default.Equals(item, value))
                count++;
        return count;
    }

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
    public static List<T> ToList<T>(params T[] array)
    {
        return array.ToList();
    }

    public static int MinElementsItemsInnerList<T>(List<List<T>> lists)
    {
        var min = int.MaxValue;
        foreach (var item in lists)
            if (item.Count < min)
                min = item.Count;
        return min;
    }
}
