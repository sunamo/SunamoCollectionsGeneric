namespace SunamoCollectionsGeneric.Collections;

/// <summary>
/// Represents the list with elements t type.
/// </summary>
public class ListWithElements<T> : L<T>
{
    /// <summary>
    /// Initializes a new instance of the list with elements class.
    /// </summary>
    /// <param name="count">The count.</param>
    public ListWithElements(int count)
    {
        for (var i = 0; i < count; i++) Add(default!);
    }
}
