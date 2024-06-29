namespace SunamoCollectionsGeneric;


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
    /// <summary>
    ///     Use Empty contstant outside of class
    /// </summary>
    /// <param name="empty"></param>
    private FromToCollectionsGeneric(bool empty)
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
    internal FromToCollectionsGeneric(long from, long to, FromToUseCollectionsGeneric ftUse = FromToUseCollectionsGeneric.DateTime)
    {
        this.from = from;
        this.to = to;
        this.ftUse = ftUse;
    }
}