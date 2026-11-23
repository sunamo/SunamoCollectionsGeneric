namespace SunamoCollectionsGeneric.Collections;

/// <summary>
/// Represents the sunamo hash set without duplicates t type.
/// </summary>
public class SunamoHashSetWithoutDuplicates<T>
{
    /// <summary>
    /// Gets or sets the items.
    /// </summary>
    public HashSet<T> Items { get; set; }

    /// <summary>
    /// Sunamo hash set without duplicates.
    /// </summary>
    /// <returns>The sunamo hash set without duplicates result.</returns>
    public SunamoHashSetWithoutDuplicates()
    {
        Items = new HashSet<T>();
    }

    /// <summary>
    /// Sunamo hash set without duplicates.
    /// </summary>
    /// <typeparam name="T">The type T.</typeparam>
    /// <returns>The sunamo hash set without duplicates result.</returns>
    public SunamoHashSetWithoutDuplicates(int capacity)
    {
        // Cant create with capacity coz is not in .NET standard
#if NETSTANDARD2_0
        Items = new HashSet<T>();
#else
        Items = new HashSet<T>(capacity);
#endif
    }

    /// <summary>
    /// Add range.
    /// </summary>
    /// <param name="list">The list.</param>
    /// <param name="progressState">The progress state.</param>
    /// <returns>The add range result.</returns>
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
