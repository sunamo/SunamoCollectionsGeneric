namespace SunamoCollectionsGeneric;

/// <summary>
/// Represents the CAG consts type.
/// </summary>
public class CAGConsts
{
    /// <summary>
    /// To array t t.
    /// </summary>
    /// <typeparam name="T">The type T.</typeparam>
    /// <param name="items">The items.</param>
    /// <returns>The to array t t result.</returns>
    public static T[] ToArrayT<T>(params T[] items)
    {
        return items;
    }

    // This must be here - SunamoValues cannot inherit from SunamoCollectionGeneric as it would create a cycle.
    // A few lines of code won't hurt.
    /// <summary>
    /// To list t.
    /// </summary>
    /// <typeparam name="T">The type T.</typeparam>
    /// <param name="items">The items.</param>
    /// <returns>The to list t result.</returns>
    public static List<T> ToList<T>(params T[] items)
    {
        return items.ToList();
    }
}
