// EN: Variable names have been checked and replaced with self-descriptive names
// CZ: Názvy proměnných byly zkontrolovány a nahrazeny samopopisnými názvy
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
    public static string XBothColumnAndRowArgumentsInUniqueTableInWholeIsUniqueAsRowOrColumnWasFalse =
        "BothColumnAndRowArgumentsInUniqueTableInWholeIsUniqueAsRowOrColumnWasFalse";

    public static string XDifferentCountInputElementsOfArrayInUniqueTableInWholeAddCells =
        "DifferentCountInputElementsOfArrayInUniqueTableInWholeAddCells";

    private int _actualRow;
    private readonly int _cells;
    private readonly string[,] _rows;

    public UniqueTableInWhole(int columnCount, int rowCount)
    {
        _cells = columnCount;
        _rows = new string[rowCount, columnCount];
    }


    private bool IsColumnUnique(int columnIndex, int rowsCount)
    {
        var hs = new HashSet<string>();
        for (var rowIndex = 0; rowIndex < rowsCount; rowIndex++) hs.Add(_rows[rowIndex, columnIndex]);

        return hs.Count == rowsCount;
    }

    private bool IsRowUnique(int rowIndex, int columnsCount)
    {
        var hs = new HashSet<string>();
        for (var columnIndex = 0; columnIndex < columnsCount; columnIndex++) hs.Add(_rows[rowIndex, columnIndex]);

        return hs.Count == columnsCount;
    }

    /// <summary>
    ///     If A1, must be all columns in all rows unique
    ///     Ïf A2, must be all rows in all columns unique
    /// </summary>
    /// <param name="isColumnsUnique"></param>
    /// <param name="isRowsUnique"></param>
    public bool IsUniqueAsRowsOrColumns(bool isColumnsUnique, bool isRowsUnique)
    {
        if (!isColumnsUnique && !isRowsUnique)
            throw new Exception(XBothColumnAndRowArgumentsInUniqueTableInWholeIsUniqueAsRowOrColumnWasFalse + ".");

        var rowsCount = _rows.GetLength(0);
        var columnsCount = _rows.GetLength(1);

        if (isColumnsUnique)
            for (var rowIndex = 0; rowIndex < rowsCount; rowIndex++)
                if (!IsRowUnique(rowIndex, columnsCount))
                    return false;

        if (isRowsUnique)
            for (var columnIndex = 0; columnIndex < columnsCount; columnIndex++)
                if (!IsColumnUnique(columnIndex, rowsCount))
                    return false;

        return true;
    }

    public void AddCells(List<string> cells)
    {
        if (cells.Count != _cells) throw new Exception(XDifferentCountInputElementsOfArrayInUniqueTableInWholeAddCells);

        for (var i = 0; i < cells.Count; i++) _rows[_actualRow, i] = cells[i];

        _actualRow++;
    }
}