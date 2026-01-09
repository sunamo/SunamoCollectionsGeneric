// variables names: ok
namespace SunamoCollectionsGeneric._sunamo.SunamoTextOutputGenerator;

internal class TextOutputGeneratorArgs
{
    internal string Delimiter { get; set; } = Environment.NewLine;
    internal bool IsHeaderWrappedEmptyLines { get; set; } = true;
    internal bool ShouldInsertCount { get; set; }
    internal string WhenNoEntries { get; set; } = "No entries";

    internal TextOutputGeneratorArgs()
    {
    }

    internal TextOutputGeneratorArgs(bool isHeaderWrappedEmptyLines, bool shouldInsertCount)
    {
        this.IsHeaderWrappedEmptyLines = isHeaderWrappedEmptyLines;
        this.ShouldInsertCount = shouldInsertCount;
    }
}