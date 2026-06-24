namespace SunamoCollectionsGeneric;

public class CAGConsts
{
    public static T[] ToArrayT<T>(params T[] items)
    {
        return items;
    }

    // This must be here - SunamoValues cannot inherit from SunamoCollectionGeneric as it would create a cycle.
    // A few lines of code won't hurt.
    public static List<T> ToList<T>(params T[] items)
    {
        return items.ToList();
    }
}
