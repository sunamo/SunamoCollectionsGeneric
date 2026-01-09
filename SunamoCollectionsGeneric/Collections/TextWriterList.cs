// variables names: ok
namespace SunamoCollectionsGeneric.Collections;

/// <summary>
/// TextWriter implementation that writes lines to a list
/// Not working, tried with Microsoft.CodeAnalysis.SyntaxNode.WriteTo
/// </summary>
public class TextWriterList : TextWriter
{
    private readonly IList _list;

    /// <summary>
    /// Initializes a new instance that writes to the specified list
    /// </summary>
    /// <param name="list">The list to write to</param>
    public TextWriterList(IList list)
    {
        _list = list;
    }

    /// <summary>
    /// Gets the character encoding in which the output is written
    /// </summary>
    public override Encoding Encoding => Encoding.UTF8;

    /// <summary>
    /// Writes a line terminator to the text string or stream
    /// </summary>
    /// <param name="value">The string to write</param>
    public override void WriteLine(string value)
    {
        _list.Add(value);
    }
}