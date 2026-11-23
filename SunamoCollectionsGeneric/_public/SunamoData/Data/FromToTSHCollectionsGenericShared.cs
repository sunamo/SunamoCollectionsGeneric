namespace SunamoCollectionsGeneric._public.SunamoData.Data;

/// <summary>
/// Represents the from to TSH collections generic shared t type.
/// </summary>
public class FromToTSHCollectionsGenericShared<T>
{
    /// <summary>
    /// Gets or sets the is empty.
    /// </summary>
    public bool IsEmpty { get; set; }

    /// <summary>
    /// Gets or sets the from to use.
    /// </summary>
    public FromToUseCollectionsGeneric FromToUse { get; set; } = FromToUseCollectionsGeneric.DateTime;

    /// <summary>
    /// The from long.
    /// </summary>
    protected long fromLong;

    /// <summary>
    /// The to long.
    /// </summary>
    protected long toLong;

    /// <summary>
    /// Initializes a new instance of the from to TSH collections generic shared class.
    /// </summary>
    public FromToTSHCollectionsGenericShared()
    {
        var type = typeof(T);
        if (type == typeof(int)) FromToUse = FromToUseCollectionsGeneric.None;
    }

    private FromToTSHCollectionsGenericShared(bool isEmpty) : this()
    {
        this.IsEmpty = isEmpty;
    }

    /// <summary>
    /// Initializes a new instance of the from to TSH collections generic shared class.
    /// </summary>
    public FromToTSHCollectionsGenericShared(T from, T to,
        FromToUseCollectionsGeneric fromToUse = FromToUseCollectionsGeneric.DateTime) : this()
    {
        this.From = from;
        this.To = to;
        this.FromToUse = fromToUse;
    }

    /// <summary>
    /// The from.
    /// </summary>
    public T From
    {
        get => (T)(dynamic)fromLong!;
        set => fromLong = (long)(dynamic)value!;
    }

    /// <summary>
    /// The to.
    /// </summary>
    public T To
    {
        get => (T)(dynamic)toLong!;
        set => toLong = (long)(dynamic)value!;
    }

    /// <summary>
    /// Gets the from long.
    /// </summary>
    public long FromLong => fromLong;

    /// <summary>
    /// Gets the to long.
    /// </summary>
    public long ToLong => toLong;
}
