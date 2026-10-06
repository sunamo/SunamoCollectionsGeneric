namespace SunamoCollectionsGeneric.Collections;

public class SunamoHashSetWithoutDuplicates<T>
{
    public HashSet<T> Items { get; set; }

    public SunamoHashSetWithoutDuplicates()
    {
        Items = new HashSet<T>();
    }

    public SunamoHashSetWithoutDuplicates(int capacity)
    {
        // Cant create with capacity coz is not in .NET standard
#if NETSTANDARD2_0
        Items = new HashSet<T>();
#else
        Items = new HashSet<T>(capacity);
#endif
    }

    public List<T> AddRange(IList<T> list, ProgressStateCAG progressState)
    {
        var duplicates = new List<T>();
        foreach (var item in list)
        {
            if (progressState.IsRegistered) progressState.OnAnotherItem();

            if (!Items.Contains(item))
                Items.Add(item);
            else
                duplicates.Add(item);
        }

        return duplicates;
    }
}
