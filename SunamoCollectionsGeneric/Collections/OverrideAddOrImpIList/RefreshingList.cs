namespace SunamoCollectionsGeneric.Collections.OverrideAddOrImpIList;

// A list that automatically refreshes from a source list when it becomes empty
/// <summary>
/// Represents the refreshing list t type.
/// </summary>
public class RefreshingList<T> : IList<T>
{
    private List<T> innerList;
    private readonly List<T> sourceToRefresh;

    /// <summary>
    /// Initializes a new instance of the refreshing list class.
    /// </summary>
    /// <param name="sourceToRefresh">The source to refresh.</param>
    /// <param name="count">The count.</param>
    public RefreshingList(List<T> sourceToRefresh, int count)
    {
        this.sourceToRefresh = sourceToRefresh;
        innerList = new List<T>(count);
    }

    /// <summary>
    /// Initializes a new instance of the refreshing list class.
    /// </summary>
    /// <param name="sourceToRefresh">The source to refresh.</param>
    /// <param name="items">The items.</param>
    public RefreshingList(List<T> sourceToRefresh, IList<T> items)
    {
        this.sourceToRefresh = sourceToRefresh;
        innerList = new List<T>(items);
    }

    /// <summary>
    /// The this int.
    /// </summary>
    public T this[int index]
    {
        get => innerList[index];
        set => innerList[index] = value;
    }

    /// <summary>
    /// Gets the count.
    /// </summary>
    public int Count => innerList.Count;

    /// <summary>
    /// Gets the is read only.
    /// </summary>
    public bool IsReadOnly => false;

    /// <summary>
    /// Add.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns>The add result.</returns>
    public void Add(T value)
    {
        innerList.Add(value);
    }

    /// <summary>
    /// Clear.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns>The clear result.</returns>
    public void Clear()
    {
        innerList.Clear();
    }

    /// <summary>
    /// Contains.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns>The contains result.</returns>
    public bool Contains(T value)
    {
        return innerList.Contains(value);
    }

    /// <summary>
    /// Copy to.
    /// </summary>
    /// <returns>The copy to result.</returns>
    public void CopyTo(T[] array, int arrayIndex)
    {
        innerList.CopyTo(array, arrayIndex);
    }

    /// <summary>
    /// Get enumerator.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns>The get enumerator result.</returns>
    public IEnumerator<T> GetEnumerator()
    {
        return innerList.GetEnumerator();
    }

    /// <summary>
    /// Index of.
    /// </summary>
    /// <param name="array">The array.</param>
    /// <param name="arrayIndex">The array index.</param>
    /// <returns>The index of result.</returns>
    public int IndexOf(T value)
    {
        return innerList.IndexOf(value);
    }

    /// <summary>
    /// Insert.
    /// </summary>
    /// <returns>The insert result.</returns>
    public void Insert(int index, T value)
    {
        innerList.Insert(index, value);
    }

    /// <summary>
    /// Remove.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns>The remove result.</returns>
    public bool Remove(T value)
    {
        var wasRemoved = innerList.Remove(value);
        RefreshIfEmpty();
        return wasRemoved;
    }

    /// <summary>
    /// Remove at.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns>The remove at result.</returns>
    public void RemoveAt(int index)
    {
        innerList.RemoveAt(index);
        RefreshIfEmpty();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return innerList.GetEnumerator();
    }

    #region Is not in any interface

    /// <summary>
    /// Sort.
    /// </summary>
    /// <returns>The sort result.</returns>
    public void Sort()
    {
        innerList.Sort();
    }

    #endregion

    private void RefreshIfEmpty()
    {
        if (innerList.Count == 0) innerList = sourceToRefresh.ToList();
    }
}
