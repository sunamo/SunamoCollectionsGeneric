// variables names: ok
// EN: Variable names have been checked and replaced with self-descriptive names
// CZ: Názvy proměnných byly zkontrolovány a nahrazeny samopopisnými názvy
namespace SunamoCollectionsGeneric._sunamo.SunamoInterfaces.Interfaces;

internal interface IStatusBroadcaster
{
    event Action<object, object[]> NewStatus;
    void OnNewStatus(string text, params string[] parameters);
}