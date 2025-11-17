// EN: Variable names have been checked and replaced with self-descriptive names
// CZ: Názvy proměnných byly zkontrolovány a nahrazeny samopopisnými názvy

namespace SunamoCollectionsGeneric._public.SunamoData.Data;

public class FromToTSHCollectionsGenericShared<T>
{
    public bool empty;
    protected long fromL;
    public FromToUseCollectionsGeneric ftUse = FromToUseCollectionsGeneric.DateTime;
    protected long toL;

    public FromToTSHCollectionsGenericShared()
    {
        var type = typeof(T);
        if (type == typeof(int)) ftUse = FromToUseCollectionsGeneric.None;
    }


    private FromToTSHCollectionsGenericShared(bool empty) : this()
    {
        this.empty = empty;
    }


    public FromToTSHCollectionsGenericShared(T from, T to,
        FromToUseCollectionsGeneric ftUse = FromToUseCollectionsGeneric.DateTime) : this()
    {
        this.from = from;
        this.to = to;
        this.ftUse = ftUse;
    }

    public T from
    {
        get => (T)(dynamic)fromL;
        set => fromL = (long)(dynamic)value;
    }

    public T to
    {
        get => (T)(dynamic)toL;
        set => toL = (long)(dynamic)value;
    }

    public long FromL => fromL;
    public long ToL => toL;
}