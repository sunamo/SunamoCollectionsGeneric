// variables names: ok
namespace SunamoCollectionsGeneric.Collections.OverrideAddOrImpIList;

/// <summary>
/// For debug purposes. RefreshingList is derived from this.
/// </summary>
/// <typeparam name="T">The type of elements in the list.</typeparam>
public class L2<T> : RefreshingList<T>
{
    /// <summary>
    /// Initializes a new instance of the L2 class
    /// </summary>
    public L2() : base(null, 0)
    {
    }

    /// <summary>
    /// Initializes a new instance of the L2 class with elements from an existing list
    /// </summary>
    /// <param name="list">The list to copy elements from</param>
    public L2(IList<T> list) : base(null, list)
    {
    }

    /// <summary>
    /// Initializes a new instance of the L2 class with the specified capacity
    /// </summary>
    /// <param name="capacity">The initial capacity of the list</param>
    public L2(int capacity) : base(null, capacity)
    {
    }
}
