namespace SunamoCollectionsGeneric._public.SunamoData.Data;

/// <summary>
/// Generic base class for representing a from-to range
/// </summary>
/// <typeparam name="T">The type of the range values</typeparam>
public class FromToTSHCollectionsGenericShared<T>
{
    /// <summary>
    /// Gets or sets whether this range is empty
    /// </summary>
    public bool IsEmpty { get; set; }

    /// <summary>
    /// Gets or sets the type of date/time representation to use
    /// </summary>
    public FromToUseCollectionsGeneric FromToUse { get; set; } = FromToUseCollectionsGeneric.DateTime;

    /// <summary>
    /// Internal storage for the start of the range as a long value
    /// </summary>
    protected long fromLong;

    /// <summary>
    /// Internal storage for the end of the range as a long value
    /// </summary>
    protected long toLong;

    /// <summary>
    /// Initializes a new instance of the FromToTSHCollectionsGenericShared class
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
    /// Initializes a new instance with the specified range
    /// </summary>
    /// <param name="from">The start of the range</param>
    /// <param name="to">The end of the range</param>
    /// <param name="fromToUse">The type of date/time representation to use</param>
    public FromToTSHCollectionsGenericShared(T from, T to,
        FromToUseCollectionsGeneric fromToUse = FromToUseCollectionsGeneric.DateTime) : this()
    {
        this.From = from;
        this.To = to;
        this.FromToUse = fromToUse;
    }

    /// <summary>
    /// Gets or sets the start of the range
    /// </summary>
    public T From
    {
        get => (T)(dynamic)fromLong!;
        set => fromLong = (long)(dynamic)value!;
    }

    /// <summary>
    /// Gets or sets the end of the range
    /// </summary>
    public T To
    {
        get => (T)(dynamic)toLong!;
        set => toLong = (long)(dynamic)value!;
    }

    /// <summary>
    /// Gets the start of the range as a long value
    /// </summary>
    public long FromLong => fromLong;

    /// <summary>
    /// Gets the end of the range as a long value
    /// </summary>
    public long ToLong => toLong;
}
