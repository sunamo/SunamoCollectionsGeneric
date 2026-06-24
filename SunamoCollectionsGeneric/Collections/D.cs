namespace SunamoCollectionsGeneric.Collections;

// Must be IEnumerable, not IList.
public class D<T, U> : ISunamoDictionary<T, U>, IEnumerable, IDictionary<T, U> where T : notnull
{
    public Action? CallWhenIsZeroElements { get; set; }
    private readonly Dictionary<T, U> dictionary = new();

    IEnumerator IEnumerable.GetEnumerator()
    {
        return dictionary.GetEnumerator();
    }

    public U this[T key]
    {
        get
        {
            if (CallWhenIsZeroElements != null)
                if (Count == 0)
                    CallWhenIsZeroElements.Invoke();
            return dictionary[key];
        }
        set
        {
            dictionary[key] = value;
        }
    }

    public ICollection<T> Keys => dictionary.Keys;

    public ICollection<U> Values => dictionary.Values;

    public int Count => dictionary.Count;

    public bool IsReadOnly => false;

    public void Add(T key, U value)
    {
        dictionary.Add(key, value);
    }

    public void Add(KeyValuePair<T, U> pair)
    {
        dictionary.Add(pair.Key, pair.Value);
    }

    public void Clear()
    {

        dictionary.Clear();
    }

    public bool Contains(KeyValuePair<T, U> pair)
    {
        return dictionary.Contains(pair);
    }

    public bool ContainsKey(T key)
    {
        return dictionary.ContainsKey(key);
    }

    public void CopyTo(KeyValuePair<T, U>[] array, int arrayIndex)
    {
        ThrowEx.NotImplementedMethod();
    }

    public IEnumerator<KeyValuePair<T, U>> GetEnumerator()
    {
        return dictionary.GetEnumerator();
    }

    public bool Remove(T key)
    {
        return dictionary.Remove(key);
    }

    public bool Remove(KeyValuePair<T, U> pair)
    {
        return dictionary.Remove(pair.Key);
    }

    public bool TryGetValue(T key, out U value)
    {
        return dictionary.TryGetValue(key, out value!);
    }

}
