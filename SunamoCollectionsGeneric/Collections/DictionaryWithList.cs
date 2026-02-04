namespace SunamoCollectionsGeneric.Collections;

/// <summary>
/// Dictionary implementation backed by a list for maintaining insertion order
/// </summary>
/// <typeparam name="T">The type of keys</typeparam>
/// <typeparam name="U">The type of values</typeparam>
public class DictionaryWithList<T, U> : IDictionary<T, U>
{
    /// <summary>
    /// Gets or sets an action to call when the collection has zero elements during indexer access
    /// </summary>
    public Action CallWhenIsZeroElements { get; set; }
    private readonly List<KeyValuePair<T, U>> items = new();

    /// <summary>
    /// Gets or sets the value associated with the specified key
    /// </summary>
    /// <param name="key">The key of the value to get or set</param>
    /// <returns>The value associated with the specified key</returns>
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

    /// <summary>
    /// Gets a collection containing the keys in the dictionary
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
    /// Gets a collection containing the values in the dictionary
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
    /// Gets the number of key/value pairs contained in the dictionary
    /// </summary>
    public int Count => items.Count;

    /// <summary>
    /// Gets a value indicating whether the dictionary is read-only
    /// </summary>
    public bool IsReadOnly => false;

    /// <summary>
    /// Adds the specified key and value to the dictionary
    /// </summary>
    /// <param name="key">The key to add</param>
    /// <param name="value">The value to add</param>
    public void Add(T key, U value)
    {
        items.Add(new KeyValuePair<T, U>(key, value));
    }

    /// <summary>
    /// Adds the specified key/value pair to the dictionary
    /// </summary>
    /// <param name="item">The key/value pair to add</param>
    public void Add(KeyValuePair<T, U> item)
    {
        items.Add(item);
    }

    /// <summary>
    /// Removes all keys and values from the dictionary
    /// </summary>
    public void Clear()
    {
        items.Clear();
    }

    /// <summary>
    /// Determines whether the dictionary contains the specified key/value pair
    /// </summary>
    /// <param name="item">The key/value pair to locate</param>
    /// <returns>True if the item is found; otherwise, false</returns>
    public bool Contains(KeyValuePair<T, U> item)
    {
        return ContainsKey(item.Key);
    }

    /// <summary>
    /// Determines whether the dictionary contains the specified key
    /// </summary>
    /// <param name="key">The key to locate</param>
    /// <returns>True if the dictionary contains an element with the specified key; otherwise, false</returns>
    public bool ContainsKey(T key)
    {
        foreach (var item in items)
            if (EqualityComparer<T>.Default.Equals(item.Key, key))
                return true;
        return false;
    }

    /// <summary>
    /// Copies the elements of the dictionary to an array, starting at the specified array index
    /// </summary>
    /// <param name="array">The destination array</param>
    /// <param name="arrayIndex">The zero-based index in array at which copying begins</param>
    public void CopyTo(KeyValuePair<T, U>[] array, int arrayIndex)
    {
        ThrowEx.NotImplementedMethod();
        //DictionaryHelper.CopyTo<T, U>(tu, array, arrayIndex);
    }

    /// <summary>
    /// Returns an enumerator that iterates through the dictionary
    /// </summary>
    /// <returns>An enumerator for the dictionary</returns>
    public IEnumerator<KeyValuePair<T, U>> GetEnumerator()
    {
        return items.GetEnumerator();
    }

    /// <summary>
    /// Removes the value with the specified key from the dictionary
    /// </summary>
    /// <param name="key">The key of the element to remove</param>
    /// <returns>True if the element is successfully found and removed; otherwise, false</returns>
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
    /// Removes the specified key/value pair from the dictionary
    /// </summary>
    /// <param name="item">The key/value pair to remove</param>
    /// <returns>True if the item is successfully found and removed; otherwise, false</returns>
    public bool Remove(KeyValuePair<T, U> item)
    {
        return Remove(item.Key);
    }

    /// <summary>
    /// Gets the value associated with the specified key
    /// </summary>
    /// <param name="key">The key of the value to get</param>
    /// <param name="value">When this method returns, contains the value associated with the specified key, if the key is found; otherwise, the default value</param>
    /// <returns>True if the dictionary contains an element with the specified key; otherwise, false</returns>
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

    /// <summary>
    /// Returns an enumerator that iterates through the dictionary
    /// </summary>
    /// <returns>An enumerator for the dictionary</returns>
    IEnumerator IEnumerable.GetEnumerator()
    {
        return items.GetEnumerator();
    }
}