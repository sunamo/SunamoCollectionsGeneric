namespace SunamoCollectionsGeneric.Data;

/// <summary>
/// Represents the t with lines t type.
/// </summary>
public class TWithLines<T>
{
    /// <summary>
    /// Gets or sets the lines.
    /// </summary>
    public L<string>? Lines { get; set; } = null;

    /// <summary>
    /// Gets or sets the value.
    /// </summary>
    public T Value { get; set; } = default!;
}
