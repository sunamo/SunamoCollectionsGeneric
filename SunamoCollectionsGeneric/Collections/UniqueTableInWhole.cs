namespace SunamoCollectionsGeneric.Collections;

/// <summary>
/// Represents the unique table in whole type.
/// </summary>
public class UniqueTableInWhole
{
    /// <summary>
    /// The x both column and row arguments in unique table in whole is unique as row or column was false constant.
    /// </summary>
    public const string XBothColumnAndRowArgumentsInUniqueTableInWholeIsUniqueAsRowOrColumnWasFalse =
        "BothColumnAndRowArgumentsInUniqueTableInWholeIsUniqueAsRowOrColumnWasFalse";

    /// <summary>
    /// The x different count input elements of array in unique table in whole add cells constant.
    /// </summary>
    public const string XDifferentCountInputElementsOfArrayInUniqueTableInWholeAddCells =
        "DifferentCountInputElementsOfArrayInUniqueTableInWholeAddCells";

    private int currentRowIndex;
    private readonly int expectedColumnCount;
    private readonly string[,] rows;

    /// <summary>
    /// Unique table in whole.
    /// </summary>
    /// <param name="columnCount">The column count.</param>
    /// <param name="rowCount">The row count.</param>
    /// <returns>The unique table in whole result.</returns>
    public UniqueTableInWhole(int columnCount, int rowCount)
    {
        expectedColumnCount = columnCount;
        rows = new string[rowCount, columnCount];
    }


    private bool IsColumnUnique(int columnIndex, int rowsCount)
    {
        var hashSet = new HashSet<string>();
        for (var rowIndex = 0; rowIndex < rowsCount; rowIndex++) hashSet.Add(rows[rowIndex, columnIndex]);

        return hashSet.Count == rowsCount;
    }

    private bool IsRowUnique(int rowIndex, int columnsCount)
    {
        var hashSet = new HashSet<string>();
        for (var columnIndex = 0; columnIndex < columnsCount; columnIndex++) hashSet.Add(rows[rowIndex, columnIndex]);

        return hashSet.Count == columnsCount;
    }

    /// <summary>
    /// Is unique as rows or columns.
    /// </summary>
    /// <typeparam name="string">The type string.</typeparam>
    /// <returns>The is unique as rows or columns result.</returns>
    public bool IsUniqueAsRowsOrColumns(bool isColumnsUnique, bool isRowsUnique)
    {
        if (!isColumnsUnique && !isRowsUnique)
            throw new Exception(XBothColumnAndRowArgumentsInUniqueTableInWholeIsUniqueAsRowOrColumnWasFalse + ".");

        var rowsCount = rows.GetLength(0);
        var columnsCount = rows.GetLength(1);

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
    /// Initializes a new instance of the add cells class.
    /// </summary>
    /// <param name="rowsCount)">The rows count.</param>
    public void AddCells(List<string> cells)
    {
        if (cells.Count != expectedColumnCount) throw new Exception(XDifferentCountInputElementsOfArrayInUniqueTableInWholeAddCells);

        for (var i = 0; i < cells.Count; i++) rows[currentRowIndex, i] = cells[i];

        currentRowIndex++;
    }
}
