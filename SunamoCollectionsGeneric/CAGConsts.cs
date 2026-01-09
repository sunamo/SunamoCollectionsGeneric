// variables names: ok
namespace SunamoCollectionsGeneric;

/// <summary>
/// Collection helper constants and utility methods for generic collections
/// </summary>
public class CAGConsts
{
    /// <summary>
    /// Converts variable arguments to an array
    /// </summary>
    /// <typeparam name="T">The type of elements</typeparam>
    /// <param name="items">The items to convert to an array</param>
    /// <returns>An array containing the provided items</returns>
    public static T[] ToArrayT<T>(params T[] items)
    {
        return items;
    }

    /// <summary>
    /// This must be here - SunamoValues cannot inherit from SunamoCollectionGeneric as it would create a cycle.
    /// A few lines of code won't hurt.
    /// </summary>
    /// <typeparam name="T">The type of elements.</typeparam>
    /// <param name="items">The items to convert to a list.</param>
    /// <returns>A list containing the provided items.</returns>
    public static List<T> ToList<T>(params T[] items)
    {
        return items.ToList();
    }
}