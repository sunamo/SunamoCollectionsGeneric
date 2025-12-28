namespace SunamoCollectionsGeneric._public.SunamoData.Data;

public class FromToTSHCollectionsGenericShared<T>
{
    public bool IsEmpty { get; set; }
    protected long fromL;
    public FromToUseCollectionsGeneric FtUse { get; set; } = FromToUseCollectionsGeneric.DateTime;
    protected long toL;

    public FromToTSHCollectionsGenericShared()
    {
        var type = typeof(T);
        if (type == typeof(int)) FtUse = FromToUseCollectionsGeneric.None;
    }


    private FromToTSHCollectionsGenericShared(bool isEmpty) : this()
    {
        this.IsEmpty = isEmpty;
    }


    public FromToTSHCollectionsGenericShared(T from, T to,
        FromToUseCollectionsGeneric ftUse = FromToUseCollectionsGeneric.DateTime) : this()
    {
        this.From = from;
        this.To = to;
        this.FtUse = ftUse;
    }

    public T From
    {
        get => (T)(dynamic)fromL;
        set => fromL = (long)(dynamic)value;
    }

    public T To
    {
        get => (T)(dynamic)toL;
        set => toL = (long)(dynamic)value;
    }

    public long FromL => fromL;
    public long ToL => toL;
}