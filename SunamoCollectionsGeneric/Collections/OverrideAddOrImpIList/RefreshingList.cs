namespace SunamoCollectionsGeneric.Collections.OverrideAddOrImpIList;

/// <summary>
/// A list that automatically refreshes from a source list when it becomes empty
/// </summary>
/// <typeparam name="T">The type of elements in the list</typeparam>
public class RefreshingList<T> : IList<T>
{
    private List<T> innerList;
    private readonly List<T> sourceToRefresh;

    /// <summary>
    /// Initializes a new instance with a source list and initial capacity
    /// </summary>
    /// <param name="sourceToRefresh">The source list to refresh from when empty</param>
    /// <param name="count">The initial capacity</param>
    public RefreshingList(List<T> sourceToRefresh, int count)
    {
        this.sourceToRefresh = sourceToRefresh;
        innerList = new List<T>(count);
    }

    /// <summary>
    /// Initializes a new instance with a source list and initial items
    /// </summary>
    /// <param name="sourceToRefresh">The source list to refresh from when empty</param>
    /// <param name="items">The initial items to populate the list</param>
    public RefreshingList(List<T> sourceToRefresh, IList<T> items)
    {
        this.sourceToRefresh = sourceToRefresh;
        innerList = new List<T>(items);
    }

    /// <summary>
    /// Gets or sets the element at the specified index
    /// </summary>
    /// <param name="index">The zero-based index of the element</param>
    /// <returns>The element at the specified index</returns>
    public T this[int index]
    {
        get => innerList[index];
        set => innerList[index] = value;
    }

    /// <summary>
    /// Gets the number of elements contained in the list
    /// </summary>
    public int Count => innerList.Count;

    /// <summary>
    /// Gets a value indicating whether the list is read-only
    /// </summary>
    public bool IsReadOnly => false;

    /// <summary>
    /// Adds a value to the list
    /// </summary>
    /// <param name="value">The value to add</param>
    public void Add(T value)
    {
        innerList.Add(value);
    }

    /// <summary>
    /// Removes all values from the list
    /// </summary>
    public void Clear()
    {
        innerList.Clear();
    }

    /// <summary>
    /// Determines whether the list contains a specific value
    /// </summary>
    /// <param name="value">The value to locate</param>
    /// <returns>True if value is found; otherwise, false</returns>
    public bool Contains(T value)
    {
        return innerList.Contains(value);
    }

    /// <summary>
    /// Copies the elements to an array, starting at a particular array index
    /// </summary>
    /// <param name="array">The destination array</param>
    /// <param name="arrayIndex">The zero-based index at which copying begins</param>
    public void CopyTo(T[] array, int arrayIndex)
    {
        innerList.CopyTo(array, arrayIndex);
    }

    /// <summary>
    /// Returns an enumerator that iterates through the list
    /// </summary>
    /// <returns>An enumerator for the list</returns>
    public IEnumerator<T> GetEnumerator()
    {
        return innerList.GetEnumerator();
    }

    /// <summary>
    /// Determines the index of a specific value in the list
    /// </summary>
    /// <param name="value">The value to locate</param>
    /// <returns>The index of value if found; otherwise, -1</returns>
    public int IndexOf(T value)
    {
        return innerList.IndexOf(value);
    }

    /// <summary>
    /// Inserts a value at the specified index
    /// </summary>
    /// <param name="index">The zero-based index at which value should be inserted</param>
    /// <param name="value">The value to insert</param>
    public void Insert(int index, T value)
    {
        innerList.Insert(index, value);
    }

    /// <summary>
    /// Removes the first occurrence of a specific value from the list
    /// </summary>
    /// <param name="value">The value to remove</param>
    /// <returns>True if value was successfully removed; otherwise, false</returns>
    public bool Remove(T value)
    {
        var wasRemoved = innerList.Remove(value);
        RefreshIfEmpty();
        return wasRemoved;
    }

    /// <summary>
    /// Removes the item at the specified index
    /// </summary>
    /// <param name="index">The zero-based index of the item to remove</param>
    public void RemoveAt(int index)
    {
        innerList.RemoveAt(index);
        RefreshIfEmpty();
    }

    /// <summary>
    /// Returns an enumerator that iterates through the list
    /// </summary>
    /// <returns>An enumerator for the list</returns>
    IEnumerator IEnumerable.GetEnumerator()
    {
        return innerList.GetEnumerator();
    }

    #region Is not in any interface

    /// <summary>
    /// Sorts the elements in the entire list
    /// </summary>
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