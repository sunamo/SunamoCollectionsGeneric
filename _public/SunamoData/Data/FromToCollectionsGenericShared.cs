namespace SunamoCollectionsGeneric;






public class FromToCollectionsGenericShared : FromToTSHCollectionsGenericShared<long>
{
    public static FromToCollectionsGenericShared Empty = new(true);
    public FromToCollectionsGenericShared()
    {
    }
    
    
    
    
    private FromToCollectionsGenericShared(bool empty)
    {
        this.empty = empty;
    }
    
    
    
    
    
    
    
    public FromToCollectionsGenericShared(long from, long to, FromToUseCollectionsGeneric ftUse = FromToUseCollectionsGeneric.DateTime)
    {
        this.from = from;
        this.to = to;
        this.ftUse = ftUse;
    }
}