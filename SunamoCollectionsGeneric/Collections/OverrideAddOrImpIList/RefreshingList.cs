namespace SunamoCollectionsGeneric.Collections.OverrideAddOrImpIList;

// A list that automatically refreshes from a source list when it becomes empty
public class RefreshingList<T> : IList<T>
{
    private List<T> innerList;
    private readonly List<T> sourceToRefresh;

    public RefreshingList(List<T> sourceToRefresh, int count)
    {
        this.sourceToRefresh = sourceToRefresh;
        innerList = new List<T>(count);
    }

    public RefreshingList(List<T> sourceToRefresh, IList<T> items)
    {
        this.sourceToRefresh = sourceToRefresh;
        innerList = new List<T>(items);
    }

    public T this[int index]
    {
        get => innerList[index];
        set => innerList[index] = value;
    }

    public int Count => innerList.Count;

    public bool IsReadOnly => false;

    public void Add(T value)
    {
        innerList.Add(value);
    }

    public void Clear()
    {
        innerList.Clear();
    }

    public bool Contains(T value)
    {
        return innerList.Contains(value);
    }

    public void CopyTo(T[] array, int arrayIndex)
    {
        innerList.CopyTo(array, arrayIndex);
    }

    public IEnumerator<T> GetEnumerator()
    {
        return innerList.GetEnumerator();
    }

    public int IndexOf(T value)
    {
        return innerList.IndexOf(value);
    }

    public void Insert(int index, T value)
    {
        innerList.Insert(index, value);
    }

    public bool Remove(T value)
    {
        var wasRemoved = innerList.Remove(value);
        RefreshIfEmpty();
        return wasRemoved;
    }

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
