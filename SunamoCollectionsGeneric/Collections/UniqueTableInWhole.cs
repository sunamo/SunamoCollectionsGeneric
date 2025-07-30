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

    public UniqueTableInWhole(int c, int r)
    {
        _cells = c;
        _rows = new string[r, c];
    }


    private bool IsColumnUnique(int columnIndex, int rowsCount)
    {
        var hs = new HashSet<string>();
        for (var r = 0; r < rowsCount; r++) hs.Add(_rows[r, columnIndex]);

        return hs.Count == rowsCount;
    }

    private bool IsRowUnique(int rowIndex, int columnsCount)
    {
        var hs = new HashSet<string>();
        for (var c = 0; c < columnsCount; c++) hs.Add(_rows[rowIndex, c]);

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
            for (var r = 0; r < rowsCount; r++)
                if (!IsRowUnique(r, columnsCount))
                    return false;

        if (rows)
            for (var c = 0; c < columnsCount; c++)
                if (!IsColumnUnique(c, rowsCount))
                    return false;

        return true;
    }

    public void AddCells(List<string> c)
    {
        if (c.Count != _cells) throw new Exception(xDifferentCountInputElementsOfArrayInUniqueTableInWholeAddCells);

        for (var i = 0; i < c.Count; i++) _rows[_actualRow, i] = c[i];

        _actualRow++;
    }
}