namespace SunamoCollectionsGeneric._public.SunamoData.Data;

public class FromToCollectionsGenericShared : FromToTSHCollectionsGenericShared<long>
{
    public static FromToCollectionsGenericShared Empty = new(true);

    public FromToCollectionsGenericShared()
    {
    }


    private FromToCollectionsGenericShared(bool empty)
    {
        this.IsEmpty = empty;
    }


    public FromToCollectionsGenericShared(long from, long to,
        FromToUseCollectionsGeneric ftUse = FromToUseCollectionsGeneric.DateTime)
    {
        this.From = from;
        this.To = to;
        this.FtUse = ftUse;
    }
}