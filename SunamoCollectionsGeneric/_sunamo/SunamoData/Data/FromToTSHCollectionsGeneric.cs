namespace SunamoCollectionsGeneric._sunamo.SunamoData.Data;

internal class FromToTSHCollectionsGeneric<T>
{
    internal bool IsEmpty { get; set; }
    protected long fromLong;
    internal FromToUseCollectionsGeneric FromToUse { get; set; } = FromToUseCollectionsGeneric.DateTime;
    protected long toLong;

    internal FromToTSHCollectionsGeneric()
    {
        var type = typeof(T);
        if (type == typeof(int)) FromToUse = FromToUseCollectionsGeneric.None;
    }

    private FromToTSHCollectionsGeneric(bool isEmpty) : this()
    {
        this.IsEmpty = isEmpty;
    }

    internal FromToTSHCollectionsGeneric(T from, T to,
        FromToUseCollectionsGeneric fromToUse = FromToUseCollectionsGeneric.DateTime) : this()
    {
        this.From = from;
        this.To = to;
        this.FromToUse = fromToUse;
    }

    internal T From
    {
        get => (T)(dynamic)fromLong!;
        set => fromLong = (long)(dynamic)value!;
    }

    internal T To
    {
        get => (T)(dynamic)toLong!;
        set => toLong = (long)(dynamic)value!;
    }

    internal long FromLong => fromLong;
    internal long ToLong => toLong;
}
