namespace SunamoCollectionsGeneric.Collections.OverrideAddOrImpIList;

public class RefreshingList<T> : IList<T>
{
    private List<T> _list;
    private readonly List<T> sourceToRefresh;


    public RefreshingList(List<T> sourceToRefresh, int count)
    {
        this.sourceToRefresh = sourceToRefresh;
        _list = new List<T>(count);
    }

    public RefreshingList(List<T> sourceToRefresh, IList<T> items)
    {
        this.sourceToRefresh = sourceToRefresh;
        _list = new List<T>(items);
    }

    public T this[int index]
    {
        get => _list[index];
        set => _list[index] = value;
    }

    public int Count => _list.Count;

    public bool IsReadOnly => false;

    public void Add(T item)
    {
        _list.Add(item);
    }

    public void Clear()
    {
        _list.Clear();
    }

    public bool Contains(T item)
    {
        return _list.Contains(item);
    }

    public void CopyTo(T[] array, int arrayIndex)
    {
        _list.CopyTo(array, arrayIndex);
    }

    public IEnumerator<T> GetEnumerator()
    {
        return _list.GetEnumerator();
    }

    public int IndexOf(T item)
    {
        return _list.IndexOf(item);
    }

    public void Insert(int index, T item)
    {
        _list.Insert(index, item);
    }

    public bool Remove(T item)
    {
        var wasRemoved = _list.Remove(item);
        RefreshIfEmpty();
        return wasRemoved;
    }

    public void RemoveAt(int index)
    {
        _list.RemoveAt(index);
        RefreshIfEmpty();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return _list.GetEnumerator();
    }

    #region Is not in any interface

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