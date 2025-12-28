// variables names: ok
// EN: Variable names have been checked and replaced with self-descriptive names
// CZ: Názvy proměnných byly zkontrolovány a nahrazeny samopopisnými názvy
namespace SunamoCollectionsGeneric.Collections;

public class ResolvedDictionary<T, U>
{
    public Dictionary<T, U> Dictionary = new();

    public U Get(T key, Func<T, U> resolver)
    {
        if (Dictionary.ContainsKey(key)) return Dictionary[key];

        return resolver.Invoke(key);
    }
}