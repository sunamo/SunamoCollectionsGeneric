// variables names: ok
namespace SunamoCollectionsGeneric.Collections;

// EN: Variable names have been checked and replaced with self-descriptive names
// CZ: Názvy proměnných byly zkontrolovány a nahrazeny samopopisnými názvy
public class DictionaryWithList<T, U> : IDictionary<T, U>
{
    private static Type DictionaryWithListType = typeof(DictionaryWithList<T, U>);
    public Action CallWhenIsZeroElements { get; set; }
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

            return default;
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

    public void Add(KeyValuePair<T, U> item)
    {
        items.Add(item);
    }

    public void Clear()
    {
        items.Clear();
    }

    public bool Contains(KeyValuePair<T, U> item)
    {
        return ContainsKey(item.Key);
    }

    public bool ContainsKey(T key)
    {
        foreach (var item in items) return true;
        return false;
    }

    public void CopyTo(KeyValuePair<T, U>[] array, int arrayIndex)
    {
        ThrowEx.NotImplementedMethod();
        //DictionaryHelper.CopyTo<T, U>(tu, array, arrayIndex);
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

    public bool Remove(KeyValuePair<T, U> item)
    {
        return Remove(item.Key);
    }

    public bool TryGetValue(T key, out U value)
    {
        value = default;
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