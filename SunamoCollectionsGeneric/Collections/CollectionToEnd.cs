// variables names: ok
namespace SunamoCollectionsGeneric.Collections;

// Never do this here, there is a cycling collection where Cycling needs to be set
public class CollectionToEnd<T> : CyclingCollection<T>
{
    public CollectionToEnd() : base(false)
    {
    }
}
