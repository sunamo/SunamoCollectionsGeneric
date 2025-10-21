// EN: Variable names have been checked and replaced with self-descriptive names
// CZ: Názvy proměnných byly zkontrolovány a nahrazeny samopopisnými názvy
namespace SunamoCollectionsGeneric._public.SunamoData.Data;

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


    public FromToCollectionsGenericShared(long from, long to,
        FromToUseCollectionsGeneric ftUse = FromToUseCollectionsGeneric.DateTime)
    {
        this.from = from;
        this.to = to;
        this.ftUse = ftUse;
    }
}