// variables names: ok
namespace SunamoCollectionsGeneric.Collections;

/// <summary>
/// Generator that cycles through a list of items, returning to the start after reaching the end
/// </summary>
/// <typeparam name="T">The type of elements in the cycle</typeparam>
public class CycleGenerator<T>
{
    private int currentIndex;
    private readonly List<T> items = new();

    /// <summary>
    /// Initializes a new instance with the specified items to cycle through
    /// </summary>
    /// <param name="items">The items to cycle through</param>
    public CycleGenerator(List<T> items)
    {
        this.items = items;
    }

    /// <summary>
    /// Returns the next item in the cycle, wrapping to the beginning when reaching the end
    /// </summary>
    /// <returns>The next item in the cycle</returns>
    public T TakeAnother()
    {
        var result = items[currentIndex++];

        if (currentIndex == items.Count) currentIndex = 0;

        return result;
    }
}