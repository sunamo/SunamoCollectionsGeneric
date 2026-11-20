namespace SunamoCollectionsGeneric.Collections;

/// <summary>
/// Represents the bad good collection t type.
/// </summary>
public class BadGoodCollection<T>
{
    /// <summary>
    /// Gets or sets the bad.
    /// </summary>
    public List<T> Bad { get; set; } = new();
    /// <summary>
    /// Gets or sets the good.
    /// </summary>
    public List<T> Good { get; set; } = new();
}
