// variables names: ok
namespace SunamoCollectionsGeneric.Collections;

// EN: Variable names have been checked and replaced with self-descriptive names
// CZ: Názvy proměnných byly zkontrolovány a nahrazeny samopopisnými názvy
public class DictionarySort<T, U>
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

    /// <summary>
    ///     sezareno a->z, lomítko první, pak čísla, pak písmena - vše standardně. Porovnává se tak bez volání Reverse
    ///     Sorted a->z, in
    /// </summary>
    /// <param name="dictionary"></param>
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
    ///     sezareno a->z, lomítko první, pak čísla, pak písmena - vše standardně. Porovnává se tak bez volání Reverse
    /// </summary>
    /// <param name="dictionary"></param>
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
    ///     sezareno z->a, pak čísla od největších k nejmenším, lomítka až poté. Volá se reverse
    /// </summary>
    /// <param name="dictionary"></param>
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
            if (item.Value.Equals(searchValue))
                return item.Key;

        return default;
    }


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

        // Lépe jsem to tu nedokázal vymyslet :-(
        foreach (var item in list)
            if (item.Value.Equals(searchValue))
                return item.Key;

        return default;
    }
}