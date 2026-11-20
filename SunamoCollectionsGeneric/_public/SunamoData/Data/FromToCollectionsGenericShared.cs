namespace SunamoCollectionsGeneric._public.SunamoData.Data;

/// <summary>
/// Represents the from to collections generic shared type.
/// </summary>
public class FromToCollectionsGenericShared : FromToTSHCollectionsGenericShared<long>
{
    /// <summary>
    /// The empty.
    /// </summary>
    public static readonly FromToCollectionsGenericShared Empty = new(true);

    /// <summary>
    /// From to collections generic shared.
    /// </summary>
    /// <param name="true">The true.</param>
    /// <returns>The from to collections generic shared result.</returns>
    public FromToCollectionsGenericShared()
    {
    }

    private FromToCollectionsGenericShared(bool empty)
    {
        this.IsEmpty = empty;
    }

    /// <summary>
    /// From to collections generic shared.
    /// </summary>
    /// <param name="from">The from.</param>
    /// <param name="to">The to.</param>
    /// <param name="fromToUse">The from to use.</param>
    /// <returns>The from to collections generic shared result.</returns>
    public FromToCollectionsGenericShared(long from, long to,
        FromToUseCollectionsGeneric fromToUse = FromToUseCollectionsGeneric.DateTime)
    {
        this.From = from;
        this.To = to;
        this.FromToUse = fromToUse;
    }
}
