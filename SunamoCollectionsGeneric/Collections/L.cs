namespace SunamoCollectionsGeneric.Collections;

/// <summary>
/// Can be derived because of the new keyword.
/// For completely derived from IList, use RefreshingList.
/// </summary>
/// <typeparam name="T">The type of elements in the list.</typeparam>
public class L<T> : List<T>
{
    /// <summary>
    /// Gets or sets whether the list has been modified
    /// </summary>
    public bool IsChanged { get; set; }

    /// <summary>
    /// Gets or sets the default value to return when accessing an index out of bounds
    /// </summary>
    public T DefaultValue { get; set; } = default;

    /// <summary>
    /// Initializes a new instance of the L class
    /// </summary>
    public L()
    {
    }

    /// <summary>
    /// Initializes a new instance with elements from an existing collection
    /// </summary>
    /// <param name="collection">The collection to copy elements from</param>
    public L(IList<T> collection) : base(collection)
    {
    }

    /// <summary>
    /// Initializes a new instance with the specified capacity
    /// </summary>
    /// <param name="capacity">The initial capacity</param>
    public L(int capacity) : base(capacity)
    {
    }

    /// <summary>
    /// Gets the number of elements in the list (alias for Count)
    /// </summary>
    public int Length => Count;

    /// <summary>
    /// Gets or sets the element at the specified index. Before use, DefaultValue needs to be set up.
    /// </summary>
    /// <param name="index">The zero-based index of the element to get or set.</param>
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
    /// Returns this instance as an L list
    /// </summary>
    /// <returns>This instance</returns>
    public L<T> ToList()
    {
        return this;
    }
}