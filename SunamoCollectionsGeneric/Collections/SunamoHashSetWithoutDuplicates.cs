// variables names: ok
// EN: Variable names have been checked and replaced with self-descriptive names
// CZ: Názvy proměnných byly zkontrolovány a nahrazeny samopopisnými názvy
namespace SunamoCollectionsGeneric.Collections;

public class SunamoHashSetWithoutDuplicates<T>
{
    public HashSet<T> Items;

    public SunamoHashSetWithoutDuplicates()
    {
        Items = new HashSet<T>();
    }

    public SunamoHashSetWithoutDuplicates(int capacity)
    {
        // Cant create with capacity coz is not in .NET standard
        Items = new HashSet<T>(capacity);
    }

    public List<T> AddRange(IList<T> elements, ProgressStateCAG progressState)
    {
        var data = new List<T>();
        foreach (var item in elements)
        {
            if (progressState.IsRegistered) progressState.OnAnotherSong();

            if (!Items.Contains(item))
                Items.Add(item);
            else
                data.Add(item);
        }

        return data;
    }
}