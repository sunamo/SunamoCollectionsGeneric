namespace SunamoCollectionsGeneric._public.SunamoEnums.Enums;

/// <summary>
/// Specifies the type of date/time representation to use for FromTo conversions.
/// </summary>
public enum FromToUseCollectionsGeneric
{
    /// <summary>
    /// Use DateTime representation.
    /// </summary>
    DateTime,

    /// <summary>
    /// Use Unix timestamp representation.
    /// </summary>
    Unix,

    /// <summary>
    /// Use Unix timestamp for time only (without date).
    /// </summary>
    UnixJustTime,

    /// <summary>
    /// No specific representation.
    /// </summary>
    None
}