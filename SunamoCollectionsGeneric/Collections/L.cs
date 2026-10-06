namespace SunamoCollectionsGeneric.Collections;

// Can be derived because of the new keyword.
// For completely derived from IList, use RefreshingList.
public class L<T> : List<T>
{
    public bool IsChanged { get; set; }

    public T DefaultValue { get; set; } = default!;

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

    // Gets or sets the element at the specified index. Before use, DefaultValue needs to be set up.
    public new T this[int index]
    {
        set
        {
            IsChanged = true;
            base[index] = value;
        }
        get
        {
            if (Length > index) return base[index];
            return DefaultValue;
        }
    }

    public L<T> ToList()
    {
        return this;
    }
}
