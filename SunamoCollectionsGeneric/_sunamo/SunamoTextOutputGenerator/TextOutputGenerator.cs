namespace SunamoCollectionsGeneric._sunamo.SunamoTextOutputGenerator;

internal class TextOutputGenerator
{
    internal StringBuilder Builder = new();

    public override string ToString()
    {
        var result = Builder.ToString();
        return result;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal void Append(string text)
    {
        Builder.Append(text);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal void AppendLine(string text)
    {
        Builder.AppendLine(text);
    }

    internal void List<TValue>(IList<TValue> items, string delimiter = "\r\n", string whenNoEntries = "")
    {
        if (items.Count() == 0)
            Builder.AppendLine(whenNoEntries);
        else
            foreach (var item in items)
                Append(item + delimiter);
    }

    internal void List(IList<string> items, string header)
    {
        List(items, header, new TextOutputGeneratorArgs { IsHeaderWrappedEmptyLines = true, ShouldInsertCount = false });
    }

    internal void List<THeader, TValue>(IList<TValue> items, THeader header, TextOutputGeneratorArgs args)
        where THeader : IEnumerable<char>
    {
        if (args.IsHeaderWrappedEmptyLines) Builder.AppendLine();
        Builder.AppendLine(header + ":");
        if (args.IsHeaderWrappedEmptyLines) Builder.AppendLine();
        List(items, args.Delimiter, args.WhenNoEntries);
    }
}
