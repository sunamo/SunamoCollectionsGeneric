namespace SunamoCollectionsGeneric._public.SunamoData.Data;

public class FromToTSHCollectionsGenericShared<T>
{
    public bool IsEmpty { get; set; }

    public FromToUseCollectionsGeneric FromToUse { get; set; } = FromToUseCollectionsGeneric.DateTime;

    protected long fromLong;

    protected long toLong;

    public FromToTSHCollectionsGenericShared()
    {
        var type = typeof(T);
        if (type == typeof(int)) FromToUse = FromToUseCollectionsGeneric.None;
    }

    private FromToTSHCollectionsGenericShared(bool isEmpty) : this()
    {
        this.IsEmpty = isEmpty;
    }

    public FromToTSHCollectionsGenericShared(T from, T to,
        FromToUseCollectionsGeneric fromToUse = FromToUseCollectionsGeneric.DateTime) : this()
    {
        this.From = from;
        this.To = to;
        this.FromToUse = fromToUse;
    }

    public T From
    {
        get => (T)(dynamic)fromLong!;
        set => fromLong = (long)(dynamic)value!;
    }

    public T To
    {
        get => (T)(dynamic)toLong!;
        set => toLong = (long)(dynamic)value!;
    }

    public long FromLong => fromLong;

    public long ToLong => toLong;
}
