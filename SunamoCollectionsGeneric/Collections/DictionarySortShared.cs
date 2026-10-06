namespace SunamoCollectionsGeneric.Collections;

public class DictionarySort<T, U> where T : notnull
{
    public List<U> ReturnValues(Dictionary<T, U> dictionary)
    {
        var result = new List<U>();
        foreach (var item in dictionary) result.Add(item.Value);

        return result;
    }

    public List<T> ReturnKeys(Dictionary<T, U> dictionary)
    {
        var result = new List<T>();
        foreach (var item in dictionary) result.Add(item.Key);

        return result;
    }

    // Sorted a->z, slash first, then numbers, then letters - all standard. Compared without calling Reverse.
    public Dictionary<T, U> SortByKeysDesc(Dictionary<T, U> dictionary)
    {
        var keys = ReturnKeys(dictionary);
        keys.Sort();
        var result = new Dictionary<T, U>();
        foreach (var item in keys) result.Add(item, dictionary[item]);

        return result;
    }

    // Sorted a->z, slash first, then numbers, then letters - all standard. Compared without calling Reverse.
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
    public Dictionary<T, U> SortByKeysAsc(Dictionary<T, U> dictionary)
    {
        var keys = ReturnKeys(dictionary);
        keys.Sort();
        keys.Reverse();
        var result = new Dictionary<T, U>();
        foreach (var item in keys) result.Add(item, dictionary[item]);

        return result;
    }

    public Dictionary<T, List<U>> RemoveWhereIsInValueOnly1Object(Dictionary<T, List<U>> dictionary)
    {
        var result = new Dictionary<T, List<U>>();
        foreach (var item in dictionary)
            if (item.Value.Count != 1)
                result.Add(item.Key, item.Value);

        return result;
    }

    public T KeyFromValue(Dictionary<T, U> dictionary, U searchValue)
    {
        foreach (var item in dictionary)
            if (item.Value!.Equals(searchValue))
                return item.Key;

        return default!;
    }

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
