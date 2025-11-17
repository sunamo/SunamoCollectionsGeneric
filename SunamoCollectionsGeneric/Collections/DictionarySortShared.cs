// EN: Variable names have been checked and replaced with self-descriptive names
// CZ: Názvy proměnných byly zkontrolovány a nahrazeny samopopisnými názvy

namespace SunamoCollectionsGeneric.Collections;

public class DictionarySort<T, U>
{
    public List<U> ReturnValues(Dictionary<T, U> sl)
    {
        var vr = new List<U>();
        foreach (var item in sl) vr.Add(item.Value);

        return vr;
    }

    public List<T> ReturnKeys(Dictionary<T, U> sl)
    {
        var vr = new List<T>();
        foreach (var item in sl) vr.Add(item.Key);

        return vr;
    }

    /// <summary>
    ///     sezareno a->z, lomítko první, pak čísla, pak písmena - vše standardně. Porovnává se tak bez volání Reverse
    ///     Sorted a->z, in
    /// </summary>
    /// <param name="sl"></param>
    public Dictionary<T, U> SortByKeysDesc(Dictionary<T, U> sl)
    {
        var klice = ReturnKeys(sl);
        //List<U> hodnoty = VratHodnoty(sl);
        klice.Sort();
        var vr = new Dictionary<T, U>();
        foreach (var item in klice) vr.Add(item, sl[item]);

        return vr;
    }

    /// <summary>
    ///     sezareno a->z, lomítko první, pak čísla, pak písmena - vše standardně. Porovnává se tak bez volání Reverse
    /// </summary>
    /// <param name="sl"></param>
    public Dictionary<T, U> SortByValuesDesc(Dictionary<T, U> sl)
    {
        var klice = ReturnKeys(sl);
        var hodnoty = ReturnValues(sl);
        hodnoty.Sort();
        var vr = new Dictionary<T, U>();
        foreach (var item in hodnoty)
        {
            var key = KeyFromValue(vr.Count, sl, item);
            vr.Add(key, item);
        }

        return vr;
    }

    public T KeyFromValue(List<T> pridane, int p, Dictionary<T, U> sl, object item2)
    {
        var i = -1;
        var list = new List<KeyValuePair<T, U>>();
        foreach (var item in sl)
        {
            i++;
            if (i < p)
            {
                list.Add(item);
                continue;
            }

            if (!pridane.Contains(item.Key))
                if (item.Value.Equals(item2))
                    return item.Key;
            //////////ObjectHelper.ci.VratTR(item.Key) + "-" + ObjectHelper.ci.VratTR(item.Value));
        }

        foreach (var item in list)
            if (!pridane.Contains(item.Key))
                if (item.Value.Equals(item2))
                    return item.Key;

        return default;
    }

    /// <summary>
    ///     sezareno z->a, pak čísla od největších k nejmenším, lomítka až poté. Volá se reverse
    /// </summary>
    /// <param name="sl"></param>
    public Dictionary<T, U> SortByKeysAsc(Dictionary<T, U> sl)
    {
        var klice = ReturnKeys(sl);
        //List<U> hodnoty = VratHodnoty(sl);
        klice.Sort();
        klice.Reverse();
        var vr = new Dictionary<T, U>();
        foreach (var item in klice) vr.Add(item, sl[item]);

        return vr;
    }

    public Dictionary<T, List<U>> RemoveWhereIsInValueOnly1Object(Dictionary<T, List<U>> sl)
    {
        var vr = new Dictionary<T, List<U>>();
        foreach (var item in sl)
            if (item.Value.Count != 1)
                vr.Add(item.Key, item.Value);

        return vr;
    }

    public T KeyFromValue(Dictionary<T, U> sl, U item2)
    {
        foreach (var item in sl)
            if (item.Value.Equals(item2))
                return item.Key;

        return default;
    }


    public T KeyFromValue(int ïndexFromWhichSearch, Dictionary<T, U> sl, object item2)
    {
        var i = -1;
        var list = new List<KeyValuePair<T, U>>();
        foreach (var item in sl)
        {
            i++;
            if (i < ïndexFromWhichSearch)
            {
                list.Add(item);
                continue;
            }

            if (item.Value.Equals(item2)) return item.Key;
        }

        // Lépe jsem to tu nedokázal vymyslet :-(
        foreach (var item in list)
            if (item.Value.Equals(item2))
                return item.Key;

        return default;
    }
}