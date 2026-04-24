namespace SunamoCollectionsGeneric._sunamo.SunamoInterfaces.Interfaces;

/// <summary>
/// Interface for a custom dictionary implementation
/// </summary>
/// <typeparam name="T">The type of keys</typeparam>
/// <typeparam name="U">The type of values</typeparam>
internal interface ISunamoDictionary<T, U> where T : notnull
{
    /// <summary>
    /// Gets or sets the value associated with the specified key
    /// </summary>
    /// <param name="key">The key of the value to get or set</param>
    /// <returns>The value associated with the specified key</returns>
    U this[T key] { get; set; }

    /// <summary>
    /// Gets a collection containing the keys
    /// </summary>
    ICollection<T> Keys { get; }

    /// <summary>
    /// Gets a collection containing the values
    /// </summary>
    ICollection<U> Values { get; }

    /// <summary>
    /// Gets the number of key/value pairs
    /// </summary>
    int Count { get; }

    /// <summary>
    /// Gets a value indicating whether the dictionary is read-only
    /// </summary>
    bool IsReadOnly { get; }

    /// <summary>
    /// Adds the specified key and value to the dictionary
    /// </summary>
    /// <param name="key">The key to add</param>
    /// <param name="value">The value to add</param>
    void Add(T key, U value);

    /// <summary>
    /// Adds the specified key/value pair to the dictionary
    /// </summary>
    /// <param name="pair">The key/value pair to add</param>
    void Add(KeyValuePair<T, U> pair);

    /// <summary>
    /// Removes all keys and values from the dictionary
    /// </summary>
    void Clear();

    /// <summary>
    /// Determines whether the dictionary contains the specified key/value pair
    /// </summary>
    /// <param name="pair">The key/value pair to locate</param>
    /// <returns>True if the pair is found; otherwise, false</returns>
    bool Contains(KeyValuePair<T, U> pair);

    /// <summary>
    /// Determines whether the dictionary contains the specified key
    /// </summary>
    /// <param name="key">The key to locate</param>
    /// <returns>True if the dictionary contains the key; otherwise, false</returns>
    bool ContainsKey(T key);

    /// <summary>
    /// Copies the elements to an array, starting at the specified index
    /// </summary>
    /// <param name="array">The destination array</param>
    /// <param name="arrayIndex">The zero-based index at which copying begins</param>
    void CopyTo(KeyValuePair<T, U>[] array, int arrayIndex);

    /// <summary>
    /// Returns an enumerator that iterates through the dictionary
    /// </summary>
    /// <returns>An enumerator for the dictionary</returns>
    IEnumerator<KeyValuePair<T, U>> GetEnumerator();

    /// <summary>
    /// Removes the value with the specified key
    /// </summary>
    /// <param name="key">The key of the element to remove</param>
    /// <returns>True if the element was successfully removed; otherwise, false</returns>
    bool Remove(T key);

    /// <summary>
    /// Removes the specified key/value pair
    /// </summary>
    /// <param name="pair">The key/value pair to remove</param>
    /// <returns>True if the pair was successfully removed; otherwise, false</returns>
    bool Remove(KeyValuePair<T, U> pair);

    /// <summary>
    /// Gets the value associated with the specified key
    /// </summary>
    /// <param name="key">The key of the value to get</param>
    /// <param name="value">The value associated with the key, if found</param>
    /// <returns>True if the key was found; otherwise, false</returns>
    bool TryGetValue(T key, out U value);
}
