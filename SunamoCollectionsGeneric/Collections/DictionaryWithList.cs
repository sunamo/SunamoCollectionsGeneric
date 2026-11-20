namespace SunamoCollectionsGeneric.Collections;

/// <summary>
/// Represents the dictionary with list t u type.
/// </summary>
public class DictionaryWithList<T, U> : IDictionary<T, U>
{
    /// <summary>
    /// Gets or sets the call when is zero elements.
    /// </summary>
    public Action? CallWhenIsZeroElements { get; set; }
    private readonly List<KeyValuePair<T, U>> items = new();

    /// <summary>
    /// The this t.
    /// </summary>
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

    /// <summary>
    /// The keys.
    /// </summary>
    public ICollection<T> Keys
    {
        get
        {
            var result = new List<T>(items.Count);
            foreach (var item in items) result.Add(item.Key);
            return result;
        }
    }

    /// <summary>
    /// The values.
    /// </summary>
    public ICollection<U> Values
    {
        get
        {
            var result = new List<U>(items.Count);
            foreach (var item in items) result.Add(item.Value);
            return result;
        }
    }

    /// <summary>
    /// Gets the count.
    /// </summary>
    public int Count => items.Count;

    /// <summary>
    /// Gets the is read only.
    /// </summary>
    public bool IsReadOnly => false;

    /// <summary>
    /// Add.
    /// </summary>
    /// <typeparam name="U">The type U.</typeparam>
    /// <param name="items.Count">The items count.</param>
    /// <returns>The add result.</returns>
    public void Add(T key, U value)
    {
        items.Add(new KeyValuePair<T, U>(key, value));
    }

    /// <summary>
    /// Add.
    /// </summary>
    /// <param name="pair">The pair.</param>
    public void Add(KeyValuePair<T, U> pair)
    {
        items.Add(pair);
    }

    /// <summary>
    /// Clear.
    /// </summary>
    /// <param name="key">The key.</param>
    /// <param name="value">The value.</param>
    /// <returns>The clear result.</returns>
    public void Clear()
    {
        items.Clear();
    }

    /// <summary>
    /// Contains.
    /// </summary>
    /// <param name="key">The key.</param>
    /// <param name="value">The value.</param>
    /// <returns>The contains result.</returns>
    public bool Contains(KeyValuePair<T, U> pair)
    {
        return ContainsKey(pair.Key);
    }

    /// <summary>
    /// Initializes a new instance of the contains key class.
    /// </summary>
    /// <param name="value)">The value.</param>
    public bool ContainsKey(T key)
    {
        foreach (var item in items)
            if (EqualityComparer<T>.Default.Equals(item.Key, key))
                return true;
        return false;
    }

    /// <summary>
    /// Copy to.
    /// </summary>
    public void CopyTo(KeyValuePair<T, U>[] array, int arrayIndex)
    {
        ThrowEx.NotImplementedMethod();
    }

    /// <summary>
    /// Get enumerator.
    /// </summary>
    /// <param name="pair">The pair.</param>
    /// <returns>The get enumerator result.</returns>
    public IEnumerator<KeyValuePair<T, U>> GetEnumerator()
    {
        return items.GetEnumerator();
    }

    /// <summary>
    /// Remove.
    /// </summary>
    /// <param name="key">The key.</param>
    /// <returns>The remove result.</returns>
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

    /// <summary>
    /// Remove.
    /// </summary>
    /// <returns>The remove result.</returns>
    public bool Remove(KeyValuePair<T, U> pair)
    {
        return Remove(pair.Key);
    }

    /// <summary>
    /// Try get value.
    /// </summary>
    /// <param name="key">The key.</param>
    /// <returns>The try get value result.</returns>
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
