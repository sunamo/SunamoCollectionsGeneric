// variables names: ok
// EN: Variable names have been checked and replaced with self-descriptive names
// CZ: Názvy proměnných byly zkontrolovány a nahrazeny samopopisnými názvy
namespace SunamoCollectionsGeneric.Data;

public class TWithLines<T>
{
    public L<string> Lines { get; set; } = null;
    public T Value { get; set; } = default;
}