namespace SunamoCollectionsGeneric.Collections;

public class SunamoDictionarySort<T, U> : Dictionary<T, U>
{
    private readonly DictionarySort<T, U> _ss = new();

    /// <summary>
    ///     Sorting a-z. Slash as first, then numbers, then letters - all in standard.
    ///     No Reserve() calling
    /// </summary>
    /// <param name="sl"></param>
    public void SortByKeysDesc()
    {
        var sl = this.ToDictionary(entry => entry.Key,
            entry => entry.Value);
        var keys = _ss.ReturnKeys(sl);
        keys.Sort();
        Clear();
        foreach (var item in keys) Add(item, sl[item]);
    }

    /// <summary>
    ///     sezareno a->z, lomítko první, pak čísla, pak písmena - vše standardně. Porovnává se tak bez volání Reverse
    /// </summary>
    public void SortByValuesDesc()
    {
        var sl = this.ToDictionary(entry => entry.Key,
            entry => entry.Value);
        var keys = _ss.ReturnKeys(sl);
        var values = _ss.ReturnValues(sl);
        values.Sort();
        Clear();

        var addedKeys = new List<T>();
        foreach (var item in values)
        {
            var key = _ss.KeyFromValue(addedKeys, Count, sl, item);
            addedKeys.Add(key);
            Add(key, item);
            //vr.Add(temp, item);
        }
    }

    private Dictionary<T, U> ToDictionary()
    {
        return this;
    }

    /// <summary>
    ///     z-a, then numbers 9-0, then slash. Call Reverse()
    /// </summary>
    /// <param name="sl"></param>
    public void SortByKeyAsc()
    {
        var sl = this.ToDictionary(entry => entry.Key,
            entry => entry.Value);
        var keys = _ss.ReturnKeys(this);
        //List<U> values = VratHodnoty(sl);
        keys.Sort();
        keys.Reverse();
        //Dictionary<temp, U> vr = new Dictionary<temp, U>();
        Clear();
        foreach (var item in keys) Add(item, sl[item]);
    }

    /// <summary>
    ///     z-a, then numbers 9-0, then slash. Call Reverse()
    /// </summary>
    public void SortByValuesAsc()
    {
        var sl = this.ToDictionary(entry => entry.Key,
            entry => entry.Value);
        var keys = _ss.ReturnKeys(sl);
        var values = _ss.ReturnValues(sl);
        values.Sort();
        values.Reverse();
        Clear();

        foreach (var item in values)
        {
            var key = _ss.KeyFromValue(Count, sl, item);
            // Přidám do this místo do vr
            Add(key, item);
        }
    }

    /// <param name="sl"></param>
    public Dictionary<T, List<U>> RemoveWhereInValuesIsOnlyOneObject(Dictionary<T, List<U>> sl)
    {
        var result = new Dictionary<T, List<U>>();
        foreach (var item in sl)
            if (item.Value.Count != 1)
                result.Add(item.Key, item.Value);
        return result;
    }
}