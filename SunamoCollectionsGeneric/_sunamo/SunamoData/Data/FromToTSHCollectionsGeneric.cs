// EN: Variable names have been checked and replaced with self-descriptive names
// CZ: Názvy proměnných byly zkontrolovány a nahrazeny samopopisnými názvy

namespace SunamoCollectionsGeneric._sunamo.SunamoData.Data;

internal class FromToTSHCollectionsGeneric<T>
{
    internal bool empty;
    protected long fromL;
    internal FromToUseCollectionsGeneric ftUse = FromToUseCollectionsGeneric.DateTime;
    protected long toL;

    internal FromToTSHCollectionsGeneric()
    {
        var type = typeof(type);
        if (type == typeof(int)) ftUse = FromToUseCollectionsGeneric.None;
    }

    /// <summary>
    ///     Use Empty contstant outside of class
    /// </summary>
    /// <param name="empty"></param>
    private FromToTSHCollectionsGeneric(bool empty) : this()
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
    internal FromToTSHCollectionsGeneric(type from, type to,
        FromToUseCollectionsGeneric ftUse = FromToUseCollectionsGeneric.DateTime) : this()
    {
        this.from = from;
        this.to = to;
        this.ftUse = ftUse;
    }

    internal type from
    {
        get => (type)(dynamic)fromL;
        set => fromL = (long)(dynamic)value;
    }

    internal type to
    {
        get => (type)(dynamic)toL;
        set => toL = (long)(dynamic)value;
    }

    internal long FromL => fromL;
    internal long ToL => toL;
}