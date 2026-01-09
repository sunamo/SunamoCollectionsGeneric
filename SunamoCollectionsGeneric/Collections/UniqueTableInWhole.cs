// variables names: ok
namespace SunamoCollectionsGeneric.Collections;

/// <summary>
/// Represents a unique table where each row contains all columns.
/// Similar class with two dimension array is ValuesTableGrid.
/// Can be: Every column of row unique, Every row of column unique,
/// Every column as whole different, Every rows as whole different.
/// </summary>
public class UniqueTableInWhole
{
    /// <summary>
    /// Error message for when both column and row uniqueness arguments are false
    /// </summary>
    public static string XBothColumnAndRowArgumentsInUniqueTableInWholeIsUniqueAsRowOrColumnWasFalse =
        "BothColumnAndRowArgumentsInUniqueTableInWholeIsUniqueAsRowOrColumnWasFalse";

    /// <summary>
    /// Error message for when input elements count differs from expected column count
    /// </summary>
    public static string XDifferentCountInputElementsOfArrayInUniqueTableInWholeAddCells =
        "DifferentCountInputElementsOfArrayInUniqueTableInWholeAddCells";

    private int _actualRow;
    private readonly int _cells;
    private readonly string[,] _rows;

    /// <summary>
    /// Initializes a new instance with the specified dimensions
    /// </summary>
    /// <param name="columnCount">The number of columns in the table</param>
    /// <param name="rowCount">The number of rows in the table</param>
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

    /// <summary>
    /// Adds a row of cells to the table
    /// </summary>
    /// <param name="cells">The cells to add as a new row</param>
    public void AddCells(List<string> cells)
    {
        if (cells.Count != _cells) throw new Exception(XDifferentCountInputElementsOfArrayInUniqueTableInWholeAddCells);

        for (var i = 0; i < cells.Count; i++) _rows[_actualRow, i] = cells[i];

        _actualRow++;
    }
}