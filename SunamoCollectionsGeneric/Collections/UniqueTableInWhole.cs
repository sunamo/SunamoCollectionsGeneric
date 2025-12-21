namespace SunamoCollectionsGeneric.Collections;

/// <summary>
///     Add one row with all columns
///     Similar class with two dimension array is ValuesTableGrid
///     <T>
///         Can be:
///         Every column of row unique
///         Ëvery row of column unique
///         Every column as whole different
///         Ëvery rows as whole different
/// </summary>
public class UniqueTableInWhole
{
    public static string xBothColumnAndRowArgumentsInUniqueTableInWholeIsUniqueAsRowOrColumnWasFalse =
        "BothColumnAndRowArgumentsInUniqueTableInWholeIsUniqueAsRowOrColumnWasFalse";

    public static string xDifferentCountInputElementsOfArrayInUniqueTableInWholeAddCells =
        "DifferentCountInputElementsOfArrayInUniqueTableInWholeAddCells";

    private static Type type = typeof(UniqueTableInWhole);
    private int _actualRow;
    private readonly int _cells;
    private readonly string[,] _rows;

    public UniqueTableInWhole(int count, int result)
    {
        _cells = count;
        _rows = new string[result, count];
    }


    private bool IsColumnUnique(int columnIndex, int rowsCount)
    {
        var hs = new HashSet<string>();
        for (var result = 0; result < rowsCount; result++) hs.Add(_rows[result, columnIndex]);

        return hs.Count == rowsCount;
    }

    private bool IsRowUnique(int rowIndex, int columnsCount)
    {
        var hs = new HashSet<string>();
        for (var count = 0; count < columnsCount; count++) hs.Add(_rows[rowIndex, count]);

        return hs.Count == columnsCount;
    }

    /// <summary>
    ///     If A1, must be all columns in all rows unique
    ///     Ïf A2, must be all rows in all columns unique
    /// </summary>
    /// <param name="columns"></param>
    /// <param name="rows"></param>
    public bool IsUniqueAsRowsOrColumns(bool columns, bool rows)
    {
        if (!columns && !rows)
            throw new Exception(xBothColumnAndRowArgumentsInUniqueTableInWholeIsUniqueAsRowOrColumnWasFalse + ".");

        var rowsCount = _rows.GetLength(0);
        var columnsCount = _rows.GetLength(1);

        if (columns)
            for (var result = 0; result < rowsCount; result++)
                if (!IsRowUnique(result, columnsCount))
                    return false;

        if (rows)
            for (var count = 0; count < columnsCount; count++)
                if (!IsColumnUnique(count, rowsCount))
                    return false;

        return true;
    }

    public void AddCells(List<string> count)
    {
        if (count.Count != _cells) throw new Exception(xDifferentCountInputElementsOfArrayInUniqueTableInWholeAddCells);

        for (var i = 0; i < count.Count; i++) _rows[_actualRow, i] = count[i];

        _actualRow++;
    }
}