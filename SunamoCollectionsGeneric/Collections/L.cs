// EN: Variable names have been checked and replaced with self-descriptive names
// CZ: Názvy proměnných byly zkontrolovány a nahrazeny samopopisnými názvy
namespace SunamoCollectionsGeneric.Collections;

/// <summary>
///     Can be derived because new keyword
///     For completely derived from IList, use RefreshingList
/// </summary>
/// <typeparam name="T"></typeparam>
public class L<T> : List<T>
{
    public bool changed;
    public T defIfNotFoundIndex = default;

    public L()
    {
    }

    public L(IList<T> collection) : base(collection)
    {
    }

    public L(int capacity) : base(capacity)
    {
    }

    public int Length => Count;

    /// <summary>
    ///     Before use is needed set up defIfNotFoundIndex
    /// </summary>
    /// <param name="i"></param>
    public new T this[int i]
    {
        set
        {
#if DEBUG

#endif
            changed = true;
            base[i] = value;
        }
        get
        {
            if (Length > i) return base[i];
            return defIfNotFoundIndex;
        }
    }

    public L<T> ToList()
    {
        return this;
    }
}