namespace SunamoCollectionsGeneric._sunamo.SunamoData.Data;

/// <summary>
///     Must have always entered both from and to
///     None of event could have unlimited time!
/// </summary>
internal class FromToCollectionsGeneric : FromToTSHCollectionsGeneric<long>
{
    internal static FromToCollectionsGeneric Empty = new(true);

    internal FromToCollectionsGeneric()
    {
    }

    private FromToCollectionsGeneric(bool empty)
    {
        this.IsEmpty = empty;
    }

    internal FromToCollectionsGeneric(long from, long to,
        FromToUseCollectionsGeneric ftUse = FromToUseCollectionsGeneric.DateTime)
    {
        this.From = from;
        this.To = to;
        this.FtUse = ftUse;
    }
}