namespace SunamoCollectionsGeneric.Collections;

public class DictionaryWithList<T, U> : IDictionary<T, U>
{
    public Action? CallWhenIsZeroElements { get; set; }
    private readonly List<KeyValuePair<T, U>> items = new();

    public U this[T key]
    {
        get
        {
            if (CallWhenIsZeroElements != null)
                if (Count == 0)
                    CallWhenIsZeroElements.Invoke();

            foreach (var item in items)
                if (EqualityComparer<T>.Default.Equals(item.Key, key))
                    return item.Value;

            return default!;
        }
        set
        {
            for (var i = 0; i < items.Count; i++)
                if (EqualityComparer<T>.Default.Equals(items[i].Key, key))
                {
                    items[i] = new KeyValuePair<T, U>(items[i].Key, value);
                    return;
                }

            Add(key, value);
        }
    }

    public ICollection<T> Keys
    {
        get
        {
            var result = new List<T>(items.Count);
            foreach (var item in items) result.Add(item.Key);
            return result;
        }
    }

    public ICollection<U> Values
    {
        get
        {
            var result = new List<U>(items.Count);
            foreach (var item in items) result.Add(item.Value);
            return result;
        }
    }

    public int Count => items.Count;

    public bool IsReadOnly => false;

    public void Add(T key, U value)
    {
        items.Add(new KeyValuePair<T, U>(key, value));
    }

    public void Add(KeyValuePair<T, U> pair)
    {
        items.Add(pair);
    }

    public void Clear()
    {
        items.Clear();
    }

    public bool Contains(KeyValuePair<T, U> pair)
    {
        return ContainsKey(pair.Key);
    }

    public bool ContainsKey(T key)
    {
        foreach (var item in items)
            if (EqualityComparer<T>.Default.Equals(item.Key, key))
                return true;
        return false;
    }

    public void CopyTo(KeyValuePair<T, U>[] array, int arrayIndex)
    {
        ThrowEx.NotImplementedMethod();
    }

    public IEnumerator<KeyValuePair<T, U>> GetEnumerator()
    {
        return items.GetEnumerator();
    }

    public bool Remove(T key)
    {
        for (var i = 0; i < items.Count; i++)
            if (EqualityComparer<T>.Default.Equals(items[i].Key, key))
            {
                items.RemoveAt(i);
                return true;
            }

        return false;
    }

    public bool Remove(KeyValuePair<T, U> pair)
    {
        return Remove(pair.Key);
    }

    public bool TryGetValue(T key, out U value)
    {
        value = default!;
        for (var i = 0; i < items.Count; i++)
            if (EqualityComparer<T>.Default.Equals(items[i].Key, key))
            {
                value = items[i].Value;
                return true;
            }

        return false;
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return items.GetEnumerator();
    }
}
