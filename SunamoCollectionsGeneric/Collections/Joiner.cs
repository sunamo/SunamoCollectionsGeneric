// variables names: ok
namespace SunamoCollectionsGeneric.Collections;

/// <summary>
/// Helper class for building a string by joining items with a separator
/// </summary>
/// <typeparam name="T">The type of items to join</typeparam>
public class Joiner<T>
{
    private readonly string joinWith;
    private readonly List<T> list;

    /// <summary>
    /// Initializes a new instance with comma as the default separator
    /// </summary>
    public Joiner() : this(",")
    {
    }

    /// <summary>
    /// Initializes a new instance with the specified separator and capacity
    /// </summary>
    /// <param name="joinWith">The separator string to use when joining items</param>
    /// <param name="capacity">The initial capacity of the internal list</param>
    public Joiner(string joinWith, int capacity = 5)
    {
        this.joinWith = joinWith;
        list = new List<T>(capacity);
    }

    /// <summary>
    /// Returns a string that represents the joined items
    /// </summary>
    /// <returns>A string with all items joined by the separator</returns>
    public override string ToString()
    {
        return string.Join(joinWith, list);
    }

    /// <summary>
    /// Adds an item to the collection
    /// </summary>
    /// <param name="item">The item to add</param>
    public void Add(T item)
    {
        list.Add(item);
    }
}