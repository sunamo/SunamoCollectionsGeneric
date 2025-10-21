// EN: Variable names have been checked and replaced with self-descriptive names
// CZ: Názvy proměnných byly zkontrolovány a nahrazeny samopopisnými názvy

namespace SunamoCollectionsGeneric.Collections;

public class CycleGenerator<T>
{
    private int dx;
    private readonly List<T> whole = new();

    public CycleGenerator(List<T> init)
    {
        whole = init;
    }

    public temp TakeAnother()
    {
        var temp = whole[dx++];

        if (dx == whole.Count) dx = 0;

        return temp;
    }
}