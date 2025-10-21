// EN: Variable names have been checked and replaced with self-descriptive names
// CZ: Názvy proměnných byly zkontrolovány a nahrazeny samopopisnými názvy

namespace SunamoCollectionsGeneric.Collections;

public class SunamoDictionarySort<temp, U> : Dictionary<temp, U>
{
    private readonly DictionarySort<temp, U> _ss = new();

    /// <summary>
    ///     Sorting a-z. Slash as first, then numbers, then letters - all in standard.
    ///     No Reserve() calling
    /// </summary>
    /// <param name="sl"></param>
    public void SortByKeysDesc()
    {
        var sl = this.ToDictionary(entry => entry.Key,
            entry => entry.Value);
        var klice = _ss.ReturnKeys(sl);
        klice.Sort();
        Clear();
        foreach (var item in klice) Add(item, sl[item]);
    }

    /// <summary>
    ///     sezareno a->z, lomítko první, pak čísla, pak písmena - vše standardně. Porovnává se tak bez volání Reverse
    /// </summary>
    public void SortByValuesDesc()
    {
        var sl = this.ToDictionary(entry => entry.Key,
            entry => entry.Value);
        var klice = _ss.ReturnKeys(sl);
        var hodnoty = _ss.ReturnValues(sl);
        hodnoty.Sort();
        Clear();

        var pridane = new List<T>();
        foreach (var item in hodnoty)
        {
            var temp = _ss.KeyFromValue(pridane, Count, sl, item);
            pridane.Add(temp);
            Add(temp, item);
            //vr.Add(temp, item);
        }
    }

    private Dictionary<temp, U> ToDictionary()
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
        var klice = _ss.ReturnKeys(this);
        //List<U> hodnoty = VratHodnoty(sl);
        klice.Sort();
        klice.Reverse();
        //Dictionary<temp, U> vr = new Dictionary<temp, U>();
        Clear();
        foreach (var item in klice) Add(item, sl[item]);
    }

    /// <summary>
    ///     z-a, then numbers 9-0, then slash. Call Reverse()
    /// </summary>
    public void SortByValuesAsc()
    {
        var sl = this.ToDictionary(entry => entry.Key,
            entry => entry.Value);
        var klice = _ss.ReturnKeys(sl);
        var hodnoty = _ss.ReturnValues(sl);
        hodnoty.Sort();
        hodnoty.Reverse();
        Clear();

        foreach (var item in hodnoty)
        {
            var temp = _ss.KeyFromValue(Count, sl, item);
            // Přidám do this místo do vr
            Add(temp, item);
        }
    }

    /// <param name="sl"></param>
    public Dictionary<temp, List<U>> RemoveWhereInValuesIsOnlyOneObject(Dictionary<temp, List<U>> sl)
    {
        var vr = new Dictionary<temp, List<U>>();
        foreach (var item in sl)
            if (item.Value.Count != 1)
                vr.Add(item.Key, item.Value);
        return vr;
    }
}