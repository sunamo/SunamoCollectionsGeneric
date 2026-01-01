namespace SunamoCollectionsGeneric.Data;

/// <summary>
/// Container class that holds a value along with associated lines of text
/// </summary>
/// <typeparam name="T">The type of the value</typeparam>
public class TWithLines<T>
{
    /// <summary>
    /// Gets or sets the list of text lines associated with the value
    /// </summary>
    public L<string> Lines { get; set; } = null;

    /// <summary>
    /// Gets or sets the main value
    /// </summary>
    public T Value { get; set; } = default;
}