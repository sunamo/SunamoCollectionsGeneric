namespace SunamoCollectionsGeneric._public.SunamoData.Data;

/// <summary>
/// Represents a from-to range using long values
/// </summary>
public class FromToCollectionsGenericShared : FromToTSHCollectionsGenericShared<long>
{
    /// <summary>
    /// Gets an empty FromTo instance
    /// </summary>
    public static readonly FromToCollectionsGenericShared Empty = new(true);

    /// <summary>
    /// Initializes a new instance of the FromToCollectionsGenericShared class
    /// </summary>
    public FromToCollectionsGenericShared()
    {
    }

    private FromToCollectionsGenericShared(bool empty)
    {
        this.IsEmpty = empty;
    }

    /// <summary>
    /// Initializes a new instance with the specified range
    /// </summary>
    /// <param name="from">The start of the range</param>
    /// <param name="to">The end of the range</param>
    /// <param name="fromToUse">The type of date/time representation to use</param>
    public FromToCollectionsGenericShared(long from, long to,
        FromToUseCollectionsGeneric fromToUse = FromToUseCollectionsGeneric.DateTime)
    {
        this.From = from;
        this.To = to;
        this.FromToUse = fromToUse;
    }
}
