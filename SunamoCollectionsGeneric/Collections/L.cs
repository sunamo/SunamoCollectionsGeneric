namespace SunamoCollectionsGeneric.Collections;

// Can be derived because of the new keyword.
// For completely derived from IList, use RefreshingList.
/// <summary>
/// Represents the l t type.
/// </summary>
public class L<T> : List<T>
{
    /// <summary>
    /// Gets or sets the is changed.
    /// </summary>
    public bool IsChanged { get; set; }

    /// <summary>
    /// Gets or sets the default value.
    /// </summary>
    public T DefaultValue { get; set; } = default!;

    /// <summary>
    /// L.
    /// </summary>
    /// <returns>The l result.</returns>
    public L()
    {
    }

    /// <summary>
    /// L.
    /// </summary>
    /// <returns>The l result.</returns>
    public L(IList<T> collection) : base(collection)
    {
    }

    /// <summary>
    /// L.
    /// </summary>
    /// <param name="collection">The collection.</param>
    /// <returns>The l result.</returns>
    public L(int capacity) : base(capacity)
    {
    }

    /// <summary>
    /// Gets the length.
    /// </summary>
    public int Length => Count;

    // Gets or sets the element at the specified index. Before use, DefaultValue needs to be set up.
    /// <summary>
    /// The this int.
    /// </summary>
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

    /// <summary>
    /// To list.
    /// </summary>
    /// <param name="index">The index.</param>
    /// <returns>The to list result.</returns>
    public L<T> ToList()
    {
        return this;
    }
}
