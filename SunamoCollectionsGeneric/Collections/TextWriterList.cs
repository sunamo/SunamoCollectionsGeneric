namespace SunamoCollectionsGeneric.Collections;

// Not working, tried with Microsoft.CodeAnalysis.SyntaxNode.WriteTo
public class TextWriterList : TextWriter
{
    private readonly IList list;

    public TextWriterList(IList list)
    {
        this.list = list;
    }

    public override Encoding Encoding => Encoding.UTF8;

    public override void WriteLine(string? value)
    {
        list.Add(value);
    }
}
