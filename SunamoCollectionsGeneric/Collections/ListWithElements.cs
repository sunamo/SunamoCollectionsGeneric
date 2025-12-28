// variables names: ok
// EN: Variable names have been checked and replaced with self-descriptive names
// CZ: Názvy proměnných byly zkontrolovány a nahrazeny samopopisnými názvy
namespace SunamoCollectionsGeneric.Collections;

public class ListWithElements<T> : L<T>
{
    public ListWithElements(int count)
    {
        for (var i = 0; i < count; i++) Add(default);
    }
}