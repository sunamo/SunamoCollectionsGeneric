// EN: Variable names have been checked and replaced with self-descriptive names
// CZ: Názvy proměnných byly zkontrolovány a nahrazeny samopopisnými názvy
namespace SunamoCollectionsGeneric.Collections;

// Toto nikdy nedelej, je zde cycling collection, kde maaea nastavit Cycling
public class CollectionToEnd<T> : CyclingCollection<T>
{
    public CollectionToEnd() : base(false)
    {
    }
}