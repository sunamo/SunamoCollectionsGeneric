namespace SunamoCollectionsGeneric.Collections;

/// <summary>
///     Not working, tried with Microsoft.CodeAnalysis.SyntaxNode.WriteTo
/// </summary>
public class TextWriterList : TextWriter
{
    private readonly IList _list;

    public TextWriterList(IList list)
    {
        _list = list;
    }

    public override Encoding Encoding => Encoding.UTF8;

    public override void WriteLine(string value)
    {
        _list.Add(value);
    }
}