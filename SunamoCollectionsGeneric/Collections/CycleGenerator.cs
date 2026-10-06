namespace SunamoCollectionsGeneric.Collections;

public class CycleGenerator<T>
{
    private int currentIndex;
    private readonly List<T> items = new();

    public CycleGenerator(List<T> items)
    {
        this.items = items;
    }

    public T TakeAnother()
    {
        var result = items[currentIndex++];

        if (currentIndex == items.Count) currentIndex = 0;

        return result;
    }
}
