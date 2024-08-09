namespace SunamoCollectionsGeneric.Collections;

public class CycleGenerator<T>
{
    private int dx;
    private readonly List<T> whole = new();

    public CycleGenerator(List<T> init)
    {
        whole = init;
    }

    public T TakeAnother()
    {
        var t = whole[dx++];

        if (dx == whole.Count) dx = 0;

        return t;
    }
}