namespace SunamoCollectionsGeneric;


/// <summary>
///     Must have always entered both from and to
///     None of event could have unlimited time!
/// </summary>
public class FromToCollectionsGenericShared : FromToTSHCollectionsGenericShared<long>
{
    internal static FromToCollectionsGenericShared Empty = new(true);
    internal FromToCollectionsGenericShared()
    {
    }
    /// <summary>
    ///     Use Empty contstant outside of class
    /// </summary>
    /// <param name="empty"></param>
    private FromToCollectionsGenericShared(bool empty)
    {
        this.empty = empty;
    }
    /// <summary>
    ///     A3 true = DateTime
    ///     A3 False = None
    /// </summary>
    /// <param name="from"></param>
    /// <param name="to"></param>
    /// <param name="ftUse"></param>
    internal FromToCollectionsGenericShared(long from, long to, FromToUseCollectionsGeneric ftUse = FromToUseCollectionsGeneric.DateTime)
    {
        this.from = from;
        this.to = to;
        this.ftUse = ftUse;
    }
}