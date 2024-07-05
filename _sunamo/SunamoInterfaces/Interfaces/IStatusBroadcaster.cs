namespace SunamoCollectionsGeneric._sunamo.SunamoInterfaces.Interfaces;


internal interface IStatusBroadcaster
{
    event Action<object, Object[]> NewStatus;
    void OnNewStatus(string s, params string[] p);
}