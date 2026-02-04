namespace SunamoCollectionsGeneric.Collections;

/// <summary>
/// A list that is pre-initialized with a specified number of default elements
/// </summary>
/// <typeparam name="T">The type of elements in the list</typeparam>
public class ListWithElements<T> : L<T>
{
    /// <summary>
    /// Initializes a new instance with the specified number of default elements
    /// </summary>
    /// <param name="count">The number of default elements to initialize</param>
    public ListWithElements(int count)
    {
        for (var i = 0; i < count; i++) Add(default);
    }
}