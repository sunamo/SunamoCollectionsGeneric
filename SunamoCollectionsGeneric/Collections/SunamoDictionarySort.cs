namespace SunamoCollectionsGeneric.Collections;

/// <summary>
/// Dictionary with sorting capabilities for keys and values
/// </summary>
/// <typeparam name="T">The type of keys</typeparam>
/// <typeparam name="U">The type of values</typeparam>
public class SunamoDictionarySort<T, U> : Dictionary<T, U> where T : notnull
{
    private readonly DictionarySort<T, U> dictionarySort = new();

    /// <summary>
    ///     Sorting a-z. Slash as first, then numbers, then letters - all in standard.
    ///     No Reserve() calling
    /// </summary>
    public void SortByKeysDesc()
    {
        var snapshot = this.ToDictionary(entry => entry.Key,
            entry => entry.Value);
        var keys = dictionarySort.ReturnKeys(snapshot);
        keys.Sort();
        Clear();
        foreach (var item in keys) Add(item, snapshot[item]);
    }

    /// <summary>
    /// Sorted a->z, slash first, then numbers, then letters - all standard. Compared without calling Reverse.
    /// </summary>
    public void SortByValuesDesc()
    {
        var snapshot = this.ToDictionary(entry => entry.Key,
            entry => entry.Value);
        var values = dictionarySort.ReturnValues(snapshot);
        values.Sort();
        Clear();

        var addedKeys = new List<T>();
        foreach (var item in values)
        {
            var key = dictionarySort.KeyFromValue(addedKeys, Count, snapshot, item!);
            addedKeys.Add(key);
            Add(key!, item);
        }
    }

    /// <summary>
    ///     z-a, then numbers 9-0, then slash. Call Reverse()
    /// </summary>
    public void SortByKeyAsc()
    {
        var snapshot = this.ToDictionary(entry => entry.Key,
            entry => entry.Value);
        var keys = dictionarySort.ReturnKeys(this);
        keys.Sort();
        keys.Reverse();
        Clear();
        foreach (var item in keys) Add(item, snapshot[item]);
    }

    /// <summary>
    /// z-a, then numbers 9-0, then slash. Call Reverse().
    /// </summary>
    public void SortByValuesAsc()
    {
        var snapshot = this.ToDictionary(entry => entry.Key,
            entry => entry.Value);
        var values = dictionarySort.ReturnValues(snapshot);
        values.Sort();
        values.Reverse();
        Clear();

        foreach (var item in values)
        {
            var key = dictionarySort.KeyFromValue(Count, snapshot, item!);
            if (key != null)
                Add(key, item);
        }
    }

    /// <summary>
    /// Removes entries from the dictionary where the value list contains only one object
    /// </summary>
    /// <typeparam name="TValue">The type of values in the list</typeparam>
    /// <param name="dictionary">The dictionary to filter</param>
    /// <returns>A new dictionary containing only entries with more than one value</returns>
    public Dictionary<T, List<TValue>> RemoveWhereInValuesIsOnlyOneObject<TValue>(Dictionary<T, List<TValue>> dictionary)
    {
        var result = new Dictionary<T, List<TValue>>();
        foreach (var item in dictionary)
            if (item.Value.Count != 1)
                result.Add(item.Key, item.Value);
        return result;
    }
}