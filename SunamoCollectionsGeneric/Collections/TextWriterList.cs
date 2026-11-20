namespace SunamoCollectionsGeneric.Collections;

// Not working, tried with Microsoft.CodeAnalysis.SyntaxNode.WriteTo
/// <summary>
/// Represents the text writer list type.
/// </summary>
public class TextWriterList : TextWriter
{
    private readonly IList list;

    /// <summary>
    /// Initializes a new instance of the text writer list class.
    /// </summary>
    /// <param name="list">The list.</param>
    public TextWriterList(IList list)
    {
        this.list = list;
    }

    /// <summary>
    /// Gets the encoding.
    /// </summary>
    public override Encoding Encoding => Encoding.UTF8;

    /// <summary>
    /// Write line.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns>The write line result.</returns>
    public override void WriteLine(string? value)
    {
        list.Add(value);
    }
}
