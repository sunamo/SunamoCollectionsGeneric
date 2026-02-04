namespace SunamoCollectionsGeneric.Collections.OverrideAddOrImpIList;

/// <summary>
/// A list that automatically refreshes from a source list when it becomes empty
/// </summary>
/// <typeparam name="T">The type of elements in the list</typeparam>
public class RefreshingList<T> : IList<T>
{
    private List<T> _list;
    private readonly List<T> sourceToRefresh;

    /// <summary>
    /// Initializes a new instance with a source list and initial capacity
    /// </summary>
    /// <param name="sourceToRefresh">The source list to refresh from when empty</param>
    /// <param name="count">The initial capacity</param>
    public RefreshingList(List<T> sourceToRefresh, int count)
    {
        this.sourceToRefresh = sourceToRefresh;
        _list = new List<T>(count);
    }

    /// <summary>
    /// Initializes a new instance with a source list and initial items
    /// </summary>
    /// <param name="sourceToRefresh">The source list to refresh from when empty</param>
    /// <param name="items">The initial items to populate the list</param>
    public RefreshingList(List<T> sourceToRefresh, IList<T> items)
    {
        this.sourceToRefresh = sourceToRefresh;
        _list = new List<T>(items);
    }

    /// <summary>
    /// Gets or sets the element at the specified index
    /// </summary>
    /// <param name="index">The zero-based index of the element</param>
    /// <returns>The element at the specified index</returns>
    public T this[int index]
    {
        get => _list[index];
        set => _list[index] = value;
    }

    /// <summary>
    /// Gets the number of elements contained in the list
    /// </summary>
    public int Count => _list.Count;

    /// <summary>
    /// Gets a value indicating whether the list is read-only
    /// </summary>
    public bool IsReadOnly => false;

    /// <summary>
    /// Adds an item to the list
    /// </summary>
    /// <param name="item">The item to add</param>
    public void Add(T item)
    {
        _list.Add(item);
    }

    /// <summary>
    /// Removes all items from the list
    /// </summary>
    public void Clear()
    {
        _list.Clear();
    }

    /// <summary>
    /// Determines whether the list contains a specific value
    /// </summary>
    /// <param name="item">The item to locate</param>
    /// <returns>True if item is found; otherwise, false</returns>
    public bool Contains(T item)
    {
        return _list.Contains(item);
    }

    /// <summary>
    /// Copies the elements to an array, starting at a particular array index
    /// </summary>
    /// <param name="array">The destination array</param>
    /// <param name="arrayIndex">The zero-based index at which copying begins</param>
    public void CopyTo(T[] array, int arrayIndex)
    {
        _list.CopyTo(array, arrayIndex);
    }

    /// <summary>
    /// Returns an enumerator that iterates through the list
    /// </summary>
    /// <returns>An enumerator for the list</returns>
    public IEnumerator<T> GetEnumerator()
    {
        return _list.GetEnumerator();
    }

    /// <summary>
    /// Determines the index of a specific item in the list
    /// </summary>
    /// <param name="item">The item to locate</param>
    /// <returns>The index of item if found; otherwise, -1</returns>
    public int IndexOf(T item)
    {
        return _list.IndexOf(item);
    }

    /// <summary>
    /// Inserts an item at the specified index
    /// </summary>
    /// <param name="index">The zero-based index at which item should be inserted</param>
    /// <param name="item">The item to insert</param>
    public void Insert(int index, T item)
    {
        _list.Insert(index, item);
    }

    /// <summary>
    /// Removes the first occurrence of a specific object from the list
    /// </summary>
    /// <param name="item">The item to remove</param>
    /// <returns>True if item was successfully removed; otherwise, false</returns>
    public bool Remove(T item)
    {
        var wasRemoved = _list.Remove(item);
        RefreshIfEmpty();
        return wasRemoved;
    }

    /// <summary>
    /// Removes the item at the specified index
    /// </summary>
    /// <param name="index">The zero-based index of the item to remove</param>
    public void RemoveAt(int index)
    {
        _list.RemoveAt(index);
        RefreshIfEmpty();
    }

    /// <summary>
    /// Returns an enumerator that iterates through the list
    /// </summary>
    /// <returns>An enumerator for the list</returns>
    IEnumerator IEnumerable.GetEnumerator()
    {
        return _list.GetEnumerator();
    }

    #region Is not in any interface

    /// <summary>
    /// Sorts the elements in the entire list
    /// </summary>
    public void Sort()
    {
        _list.Sort();
    }

    #endregion

    private void RefreshIfEmpty()
    {
        if (_list.Count == 0) _list = sourceToRefresh.ToList();
    }
}