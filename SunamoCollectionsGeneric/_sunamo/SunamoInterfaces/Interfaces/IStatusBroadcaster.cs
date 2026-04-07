namespace SunamoCollectionsGeneric._sunamo.SunamoInterfaces.Interfaces;

/// <summary>
/// Interface for broadcasting status messages
/// </summary>
internal interface IStatusBroadcaster
{
    /// <summary>
    /// Event raised when a new status message is generated
    /// </summary>
    event Action<object, object[]> NewStatus;

    /// <summary>
    /// Triggers the NewStatus event with a formatted message
    /// </summary>
    /// <param name="text">The format string</param>
    /// <param name="parameters">The format parameters</param>
    void OnNewStatus(string text, params string[] parameters);
}
