namespace SunamoCollectionsGeneric.Collections;

// Never do this here, there is a cycling collection where Cycling needs to be set
/// <summary>
/// Represents the collection to end t type.
/// </summary>
public class CollectionToEnd<T> : CyclingCollection<T>
{
    /// <summary>
    /// Initializes a new instance of the collection to end class.
    /// </summary>
    public CollectionToEnd() : base(false)
    {
    }
}
