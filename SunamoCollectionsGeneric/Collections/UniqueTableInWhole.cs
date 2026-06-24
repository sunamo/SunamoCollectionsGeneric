namespace SunamoCollectionsGeneric.Collections;

public class UniqueTableInWhole
{
    public const string XBothColumnAndRowArgumentsInUniqueTableInWholeIsUniqueAsRowOrColumnWasFalse =
        "BothColumnAndRowArgumentsInUniqueTableInWholeIsUniqueAsRowOrColumnWasFalse";

    public const string XDifferentCountInputElementsOfArrayInUniqueTableInWholeAddCells =
        "DifferentCountInputElementsOfArrayInUniqueTableInWholeAddCells";

    private int currentRowIndex;
    private readonly int expectedColumnCount;
    private readonly string[,] rows;

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

    public void AddCells(List<string> cells)
    {
        if (cells.Count != expectedColumnCount) throw new Exception(XDifferentCountInputElementsOfArrayInUniqueTableInWholeAddCells);

        for (var i = 0; i < cells.Count; i++) rows[currentRowIndex, i] = cells[i];

        currentRowIndex++;
    }
}
