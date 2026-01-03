// variables names: ok
namespace SunamoCollectionsGeneric.Collections;

/// <summary>
/// A collection that iterates to the end without cycling back to the beginning
/// </summary>
/// <typeparam name="T">The type of elements in the collection</typeparam>
// Never do this here, there is a cycling collection where Cycling needs to be set
public class CollectionToEnd<T> : CyclingCollection<T>
{
    /// <summary>
    /// Initializes a new instance of the CollectionToEnd class with cycling disabled
    /// </summary>
    public CollectionToEnd() : base(false)
    {
    }
}
