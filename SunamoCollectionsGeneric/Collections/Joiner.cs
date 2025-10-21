// EN: Variable names have been checked and replaced with self-descriptive names
// CZ: Názvy proměnných byly zkontrolovány a nahrazeny samopopisnými názvy
namespace SunamoCollectionsGeneric.Collections;

public class Joiner<T>
{
    private readonly string joinWith;
    private readonly List<T> list;

    public Joiner() : this(",")
    {
    }


    public Joiner(string joinWith, int capacity = 5)
    {
        this.joinWith = joinWith;
        list = new List<T>(capacity);
    }

    public override string ToString()
    {
        return string.Join(joinWith, list);
    }

    public void Add(T appName)
    {
        list.Add(appName);
    }
}