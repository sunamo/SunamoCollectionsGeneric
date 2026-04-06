namespace SunamoCollectionsGeneric._sunamo.SunamoData.Data;

internal class FromToTSHCollectionsGeneric<T>
{
    internal bool IsEmpty { get; set; }
    protected long fromL;
    internal FromToUseCollectionsGeneric FtUse { get; set; } = FromToUseCollectionsGeneric.DateTime;
    protected long toL;

    internal FromToTSHCollectionsGeneric()
    {
        var type = typeof(T);
        if (type == typeof(int)) FtUse = FromToUseCollectionsGeneric.None;
    }

    private FromToTSHCollectionsGeneric(bool isEmpty) : this()
    {
        this.IsEmpty = isEmpty;
    }

    internal FromToTSHCollectionsGeneric(T from, T to,
        FromToUseCollectionsGeneric ftUse = FromToUseCollectionsGeneric.DateTime) : this()
    {
        this.From = from;
        this.To = to;
        this.FtUse = ftUse;
    }

    internal T From
    {
        get => (T)(dynamic)fromL!;
        set => fromL = (long)(dynamic)value!;
    }

    internal T To
    {
        get => (T)(dynamic)toL!;
        set => toL = (long)(dynamic)value!;
    }

    internal long FromL => fromL;
    internal long ToL => toL;
}