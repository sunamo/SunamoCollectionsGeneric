namespace SunamoCollectionsGeneric._sunamo.SunamoData.Data;

/// <summary>
///     Both from and to values must always be specified.
///     No event can have unlimited time.
/// </summary>
internal class FromToCollectionsGeneric : FromToTSHCollectionsGeneric<long>
{
    internal static readonly FromToCollectionsGeneric Empty = new(true);

    internal FromToCollectionsGeneric()
    {
    }

    private FromToCollectionsGeneric(bool empty)
    {
        this.IsEmpty = empty;
    }

    internal FromToCollectionsGeneric(long from, long to,
        FromToUseCollectionsGeneric fromToUse = FromToUseCollectionsGeneric.DateTime)
    {
        this.From = from;
        this.To = to;
        this.FromToUse = fromToUse;
    }
}
