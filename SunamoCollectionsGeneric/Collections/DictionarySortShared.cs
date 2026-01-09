// variables names: ok
namespace SunamoCollectionsGeneric.Collections;

/// <summary>
/// Helper class for sorting dictionaries by keys or values
/// </summary>
/// <typeparam name="T">The type of keys</typeparam>
/// <typeparam name="U">The type of values</typeparam>
public class DictionarySort<T, U>
{
    /// <summary>
    /// Returns all values from the dictionary as a list
    /// </summary>
    /// <param name="dictionary">The dictionary to extract values from</param>
    /// <returns>A list of all values in the dictionary</returns>
    public List<U> ReturnValues(Dictionary<T, U> dictionary)
    {
        var result = new List<U>();
        foreach (var item in dictionary) result.Add(item.Value);

        return result;
    }

    /// <summary>
    /// Returns all keys from the dictionary as a list
    /// </summary>
    /// <param name="dictionary">The dictionary to extract keys from</param>
    /// <returns>A list of all keys in the dictionary</returns>
    public List<T> ReturnKeys(Dictionary<T, U> dictionary)
    {
        var result = new List<T>();
        foreach (var item in dictionary) result.Add(item.Key);

        return result;
    }

    /// <summary>
    /// Sorted a->z, slash first, then numbers, then letters - all standard. Compared without calling Reverse.
    /// </summary>
    /// <param name="dictionary">The dictionary to sort.</param>
    /// <returns>A new dictionary sorted by keys in descending order.</returns>
    public Dictionary<T, U> SortByKeysDesc(Dictionary<T, U> dictionary)
    {
        var keys = ReturnKeys(dictionary);
        //List<U> values = VratHodnoty(dictionary);
        keys.Sort();
        var result = new Dictionary<T, U>();
        foreach (var item in keys) result.Add(item, dictionary[item]);

        return result;
    }

    /// <summary>
    /// Sorted a->z, slash first, then numbers, then letters - all standard. Compared without calling Reverse.
    /// </summary>
    /// <param name="dictionary">The dictionary to sort.</param>
    /// <returns>A new dictionary sorted by values in descending order.</returns>
    public Dictionary<T, U> SortByValuesDesc(Dictionary<T, U> dictionary)
    {
        var keys = ReturnKeys(dictionary);
        var values = ReturnValues(dictionary);
        values.Sort();
        var result = new Dictionary<T, U>();
        foreach (var item in values)
        {
            var key = KeyFromValue(result.Count, dictionary, item);
            result.Add(key, item);
        }

        return result;
    }

    /// <summary>
    /// Finds the key for a specified value, starting from a specific index and excluding already added keys
    /// </summary>
    /// <param name="addedKeys">Keys that have already been processed</param>
    /// <param name="startIndex">Index to start searching from</param>
    /// <param name="dictionary">The dictionary to search</param>
    /// <param name="searchValue">The value to find the key for</param>
    /// <returns>The key associated with the search value, or default if not found</returns>
    public T KeyFromValue(List<T> addedKeys, int startIndex, Dictionary<T, U> dictionary, object searchValue)
    {
        var i = -1;
        var list = new List<KeyValuePair<T, U>>();
        foreach (var item in dictionary)
        {
            i++;
            if (i < startIndex)
            {
                list.Add(item);
                continue;
            }

            if (!addedKeys.Contains(item.Key))
                if (item.Value.Equals(searchValue))
                    return item.Key;
            //////////ObjectHelper.ci.VratTR(item.Key) + "-" + ObjectHelper.ci.VratTR(item.Value));
        }

        foreach (var item in list)
            if (!addedKeys.Contains(item.Key))
                if (item.Value.Equals(searchValue))
                    return item.Key;

        return default;
    }

    /// <summary>
    /// Sorted z->a, then numbers from largest to smallest, slashes after. Calls reverse.
    /// </summary>
    /// <param name="dictionary">The dictionary to sort.</param>
    /// <returns>A new dictionary sorted by keys in ascending order.</returns>
    public Dictionary<T, U> SortByKeysAsc(Dictionary<T, U> dictionary)
    {
        var keys = ReturnKeys(dictionary);
        //List<U> values = VratHodnoty(dictionary);
        keys.Sort();
        keys.Reverse();
        var result = new Dictionary<T, U>();
        foreach (var item in keys) result.Add(item, dictionary[item]);

        return result;
    }

    /// <summary>
    /// Removes entries from the dictionary where the value list contains only one object
    /// </summary>
    /// <param name="dictionary">The dictionary to filter</param>
    /// <returns>A new dictionary containing only entries with more than one value</returns>
    public Dictionary<T, List<U>> RemoveWhereIsInValueOnly1Object(Dictionary<T, List<U>> dictionary)
    {
        var result = new Dictionary<T, List<U>>();
        foreach (var item in dictionary)
            if (item.Value.Count != 1)
                result.Add(item.Key, item.Value);

        return result;
    }

    /// <summary>
    /// Finds the first key associated with the specified value
    /// </summary>
    /// <param name="dictionary">The dictionary to search</param>
    /// <param name="searchValue">The value to find the key for</param>
    /// <returns>The key associated with the search value, or default if not found</returns>
    public T KeyFromValue(Dictionary<T, U> dictionary, U searchValue)
    {
        foreach (var item in dictionary)
            if (item.Value.Equals(searchValue))
                return item.Key;

        return default;
    }

    /// <summary>
    /// Finds the key for a specified value, starting from a specific index
    /// </summary>
    /// <param name="indexFromWhichSearch">Index to start searching from</param>
    /// <param name="dictionary">The dictionary to search</param>
    /// <param name="searchValue">The value to find the key for</param>
    /// <returns>The key associated with the search value, or default if not found</returns>
    public T KeyFromValue(int indexFromWhichSearch, Dictionary<T, U> dictionary, object searchValue)
    {
        var i = -1;
        var list = new List<KeyValuePair<T, U>>();
        foreach (var item in dictionary)
        {
            i++;
            if (i < indexFromWhichSearch)
            {
                list.Add(item);
                continue;
            }

            if (item.Value.Equals(searchValue)) return item.Key;
        }

        // Could not figure out a better solution here
        foreach (var item in list)
            if (item.Value.Equals(searchValue))
                return item.Key;

        return default;
    }
}