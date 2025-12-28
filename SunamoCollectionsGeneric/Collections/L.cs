namespace SunamoCollectionsGeneric.Collections;

// EN: Variable names have been checked and replaced with self-descriptive names
// CZ: Názvy proměnných byly zkontrolovány a nahrazeny samopopisnými názvy
/// <summary>
///     Can be derived because new keyword
///     For completely derived from IList, use RefreshingList
/// </summary>
/// <typeparam name="T"></typeparam>
public class L<T> : List<T>
{
    public bool IsChanged { get; set; }
    public T DefaultValue { get; set; } = default;

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
    ///     Before use is needed set up DefaultValue
    /// </summary>
    /// <param name="i"></param>
    public new T this[int i]
    {
        set
        {
#if DEBUG

#endif
            IsChanged = true;
            base[i] = value;
        }
        get
        {
            if (Length > i) return base[i];
            return DefaultValue;
        }
    }

    public L<T> ToList()
    {
        return this;
    }
}