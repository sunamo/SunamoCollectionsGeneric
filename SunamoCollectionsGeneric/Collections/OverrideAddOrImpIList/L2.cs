namespace SunamoCollectionsGeneric.Collections.OverrideAddOrImpIList;

// For debug purposes. RefreshingList is derived from this.
/// <summary>
/// Represents the l 2 t type.
/// </summary>
public class L2<T> : RefreshingList<T>
{
    /// <summary>
    /// Initializes a new instance of the l 2 class.
    /// </summary>
    public L2() : base(null!, 0)
    {
    }

    /// <summary>
    /// Initializes a new instance of the l 2 class.
    /// </summary>
    /// <param name="list">The list.</param>
    public L2(IList<T> list) : base(null!, list)
    {
    }

    /// <summary>
    /// Initializes a new instance of the l 2 class.
    /// </summary>
    /// <param name="capacity">The capacity.</param>
    public L2(int capacity) : base(null!, capacity)
    {
    }
}
