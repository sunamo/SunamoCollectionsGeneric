namespace SunamoCollectionsGeneric.Collections;

/// <summary>
/// HashSet that tracks and reports duplicate items during addition
/// </summary>
/// <typeparam name="T">The type of elements in the set</typeparam>
public class SunamoHashSetWithoutDuplicates<T>
{
    /// <summary>
    /// Gets or sets the underlying HashSet of unique items
    /// </summary>
    public HashSet<T> Items { get; set; }

    /// <summary>
    /// Initializes a new instance of the SunamoHashSetWithoutDuplicates class
    /// </summary>
    public SunamoHashSetWithoutDuplicates()
    {
        Items = new HashSet<T>();
    }

    /// <summary>
    /// Initializes a new instance with the specified capacity
    /// </summary>
    /// <param name="capacity">The initial capacity of the hash set</param>
    public SunamoHashSetWithoutDuplicates(int capacity)
    {
        // Cant create with capacity coz is not in .NET standard
        Items = new HashSet<T>(capacity);
    }

    /// <summary>
    /// Adds a range of values to the set and returns the duplicates that were not added
    /// </summary>
    /// <param name="list">The list of values to add</param>
    /// <param name="progressState">Progress state for tracking operation progress</param>
    /// <returns>A list of duplicate values that were already in the set</returns>
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