namespace SunamoCollectionsGeneric.Collections;

/// <summary>
/// Represents the dictionary sort t u type.
/// </summary>
public class DictionarySort<T, U> where T : notnull
{
    /// <summary>
    /// Return values.
    /// </summary>
    /// <param name="dictionary">The dictionary.</param>
    /// <returns>The return values result.</returns>
    public List<U> ReturnValues(Dictionary<T, U> dictionary)
    {
        var result = new List<U>();
        foreach (var item in dictionary) result.Add(item.Value);

        return result;
    }

    /// <summary>
    /// Return keys.
    /// </summary>
    /// <param name="dictionary">The dictionary.</param>
    /// <returns>The return keys result.</returns>
    public List<T> ReturnKeys(Dictionary<T, U> dictionary)
    {
        var result = new List<T>();
        foreach (var item in dictionary) result.Add(item.Key);

        return result;
    }

    // Sorted a->z, slash first, then numbers, then letters - all standard. Compared without calling Reverse.
    /// <summary>
    /// Sort by keys desc.
    /// </summary>
    /// <param name="dictionary">The dictionary.</param>
    /// <returns>The sort by keys desc result.</returns>
    public Dictionary<T, U> SortByKeysDesc(Dictionary<T, U> dictionary)
    {
        var keys = ReturnKeys(dictionary);
        keys.Sort();
        var result = new Dictionary<T, U>();
        foreach (var item in keys) result.Add(item, dictionary[item]);

        return result;
    }

    // Sorted a->z, slash first, then numbers, then letters - all standard. Compared without calling Reverse.
    /// <summary>
    /// Sort by values desc.
    /// </summary>
    /// <param name="dictionary">The dictionary.</param>
    /// <returns>The sort by values desc result.</returns>
    public Dictionary<T, U> SortByValuesDesc(Dictionary<T, U> dictionary)
    {
        var values = ReturnValues(dictionary);
        values.Sort();
        var result = new Dictionary<T, U>();
        foreach (var item in values)
        {
            var key = KeyFromValue(result.Count, dictionary, item!);
            result.Add(key, item);
        }

        return result;
    }

    /// <summary>
    /// Key from value.
    /// </summary>
    /// <param name="addedKeys">The added keys.</param>
    /// <param name="startIndex">The start index.</param>
    /// <param name="dictionary">The dictionary.</param>
    /// <param name="searchValue">The search value.</param>
    /// <returns>The key from value result.</returns>
    public T KeyFromValue(List<T> addedKeys, int startIndex, Dictionary<T, U> dictionary, object searchValue)
    {
        var currentIndex = -1;
        var skippedEntries = new List<KeyValuePair<T, U>>();
        foreach (var item in dictionary)
        {
            currentIndex++;
            if (currentIndex < startIndex)
            {
                skippedEntries.Add(item);
                continue;
            }

            if (!addedKeys.Contains(item.Key))
                if (item.Value!.Equals(searchValue))
                    return item.Key;
        }

        foreach (var item in skippedEntries)
            if (!addedKeys.Contains(item.Key))
                if (item.Value!.Equals(searchValue))
                    return item.Key;

        return default!;
    }

    // Sorted z->a, then numbers from largest to smallest, slashes after. Calls reverse.
    /// <summary>
    /// Sort by keys asc.
    /// </summary>
    /// <param name="dictionary">The dictionary.</param>
    /// <returns>The sort by keys asc result.</returns>
    public Dictionary<T, U> SortByKeysAsc(Dictionary<T, U> dictionary)
    {
        var keys = ReturnKeys(dictionary);
        keys.Sort();
        keys.Reverse();
        var result = new Dictionary<T, U>();
        foreach (var item in keys) result.Add(item, dictionary[item]);

        return result;
    }

    /// <summary>
    /// Remove where is in value only 1 object.
    /// </summary>
    /// <param name="dictionary">The dictionary.</param>
    /// <returns>The remove where is in value only 1 object result.</returns>
    public Dictionary<T, List<U>> RemoveWhereIsInValueOnly1Object(Dictionary<T, List<U>> dictionary)
    {
        var result = new Dictionary<T, List<U>>();
        foreach (var item in dictionary)
            if (item.Value.Count != 1)
                result.Add(item.Key, item.Value);

        return result;
    }

    /// <summary>
    /// Key from value.
    /// </summary>
    /// <param name="dictionary">The dictionary.</param>
    /// <param name="searchValue">The search value.</param>
    /// <returns>The key from value result.</returns>
    public T KeyFromValue(Dictionary<T, U> dictionary, U searchValue)
    {
        foreach (var item in dictionary)
            if (item.Value!.Equals(searchValue))
                return item.Key;

        return default!;
    }

    /// <summary>
    /// Key from value.
    /// </summary>
    /// <param name="startIndex">The start index.</param>
    /// <param name="dictionary">The dictionary.</param>
    /// <param name="searchValue">The search value.</param>
    /// <returns>The key from value result.</returns>
    public T KeyFromValue(int startIndex, Dictionary<T, U> dictionary, object searchValue)
    {
        var currentIndex = -1;
        var skippedEntries = new List<KeyValuePair<T, U>>();
        foreach (var item in dictionary)
        {
            currentIndex++;
            if (currentIndex < startIndex)
            {
                skippedEntries.Add(item);
                continue;
            }

            if (item.Value!.Equals(searchValue)) return item.Key;
        }

        foreach (var item in skippedEntries)
            if (item.Value!.Equals(searchValue))
                return item.Key;

        return default!;
    }
}
