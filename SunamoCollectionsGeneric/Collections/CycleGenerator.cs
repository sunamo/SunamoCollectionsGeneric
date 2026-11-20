namespace SunamoCollectionsGeneric.Collections;

/// <summary>
/// Represents the cycle generator t type.
/// </summary>
public class CycleGenerator<T>
{
    private int currentIndex;
    private readonly List<T> items = new();

    /// <summary>
    /// Initializes a new instance of the cycle generator class.
    /// </summary>
    /// <param name="items">The items.</param>
    public CycleGenerator(List<T> items)
    {
        this.items = items;
    }

    /// <summary>
    /// Take another.
    /// </summary>
    /// <returns>The take another result.</returns>
    public T TakeAnother()
    {
        var result = items[currentIndex++];

        if (currentIndex == items.Count) currentIndex = 0;

        return result;
    }
}
