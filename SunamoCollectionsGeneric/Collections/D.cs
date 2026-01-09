// variables names: ok
namespace SunamoCollectionsGeneric.Collections;

/// <summary>
/// Dictionary implementation with debugging capabilities and enumerable support
/// Must be IEnumerable, not IList.
/// </summary>
/// <typeparam name="T">The type of keys in the dictionary.</typeparam>
/// <typeparam name="U">The type of values in the dictionary.</typeparam>
public class D<T, U> : ISunamoDictionary<T, U>, IEnumerable, IDictionary<T, U>
{
    /// <summary>
    /// Gets or sets an action to call when attempting to access an empty dictionary
    /// </summary>
    public Action CallWhenIsZeroElements { get; set; }
    private readonly Dictionary<T, U> dictionary = new();

    /// <summary>
    /// Returns an enumerator that iterates through the dictionary
    /// </summary>
    /// <returns>An enumerator for the dictionary</returns>
    IEnumerator IEnumerable.GetEnumerator()
    {
        return dictionary.GetEnumerator();
    }

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
            return dictionary[key];
        }
        set
        {
            ContainsV(value);

            dictionary[key] = value;
        }
    }

    /// <summary>
    /// Gets a collection containing the keys in the dictionary
    /// </summary>
    public ICollection<T> Keys => dictionary.Keys;

    /// <summary>
    /// Gets a collection containing the values in the dictionary
    /// </summary>
    public ICollection<U> Values => dictionary.Values;

    /// <summary>
    /// Gets the number of key/value pairs contained in the dictionary
    /// </summary>
    public int Count => dictionary.Count;

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
        ContainsV(value);

        dictionary.Add(key, value);
    }

    /// <summary>
    /// Adds the specified key/value pair to the dictionary
    /// </summary>
    /// <param name="item">The key/value pair to add</param>
    public void Add(KeyValuePair<T, U> item)
    {
        ContainsV(item.Value);
        dictionary.Add(item.Key, item.Value);
    }

    /// <summary>
    /// Removes all keys and values from the dictionary
    /// </summary>
    public void Clear()
    {
#if DEBUG
        OnRemove();
#endif

        dictionary.Clear();
    }

    /// <summary>
    /// Determines whether the dictionary contains the specified key/value pair
    /// </summary>
    /// <param name="item">The key/value pair to locate</param>
    /// <returns>True if the item is found; otherwise, false</returns>
    public bool Contains(KeyValuePair<T, U> item)
    {
        return dictionary.Contains(item);
    }

    /// <summary>
    /// Determines whether the dictionary contains the specified key
    /// </summary>
    /// <param name="key">The key to locate</param>
    /// <returns>True if the dictionary contains an element with the specified key; otherwise, false</returns>
    public bool ContainsKey(T key)
    {
        return dictionary.ContainsKey(key);
    }

    /// <summary>
    /// Copies the elements of the dictionary to an array, starting at the specified array index
    /// </summary>
    /// <param name="array">The destination array</param>
    /// <param name="arrayIndex">The zero-based index in array at which copying begins</param>
    public void CopyTo(KeyValuePair<T, U>[] array, int arrayIndex)
    {
        ThrowEx.NotImplementedMethod();
        //DictionaryHelper.CopyTo<T, U>(d, array, arrayIndex);
    }

    /// <summary>
    /// Returns an enumerator that iterates through the dictionary
    /// </summary>
    /// <returns>An enumerator for the dictionary</returns>
    public IEnumerator<KeyValuePair<T, U>> GetEnumerator()
    {
        return dictionary.GetEnumerator();
    }

    /// <summary>
    /// Removes the value with the specified key from the dictionary
    /// </summary>
    /// <param name="key">The key of the element to remove</param>
    /// <returns>True if the element is successfully found and removed; otherwise, false</returns>
    public bool Remove(T key)
    {
#if DEBUG
        OnRemove();
#endif
        return dictionary.Remove(key);
    }

    /// <summary>
    /// Removes the specified key/value pair from the dictionary
    /// </summary>
    /// <param name="item">The key/value pair to remove</param>
    /// <returns>True if the item is successfully found and removed; otherwise, false</returns>
    public bool Remove(KeyValuePair<T, U> item)
    {
#if DEBUG
        OnRemove();
#endif
        return dictionary.Remove(item.Key);
    }

    /// <summary>
    /// Gets the value associated with the specified key
    /// </summary>
    /// <param name="key">The key of the value to get</param>
    /// <param name="value">When this method returns, contains the value associated with the specified key, if the key is found; otherwise, the default value</param>
    /// <returns>True if the dictionary contains an element with the specified key; otherwise, false</returns>
    public bool TryGetValue(T key, out U value)
    {
        return dictionary.TryGetValue(key, out value);
    }

    private void ContainsV(U value)
    {
#if DEBUG
        if (value.ToString().Contains(checkForContains))
        {
        }
#endif
    }
#if DEBUG
    private const string checkForContains = "ccc_netcore31";

    private void OnRemove()
    {
        Debugger.Break();
    }
#endif
}