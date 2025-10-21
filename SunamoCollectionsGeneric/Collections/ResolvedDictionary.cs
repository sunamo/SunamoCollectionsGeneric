// EN: Variable names have been checked and replaced with self-descriptive names
// CZ: Názvy proměnných byly zkontrolovány a nahrazeny samopopisnými názvy
namespace SunamoCollectionsGeneric.Collections;

public class ResolvedDictionary<T, U>
{
    public Dictionary<T, U> dict = new();

    public U Get(T idArtist, Func<T, U> nameOfArtist)
    {
        if (dict.ContainsKey(idArtist)) return dict[idArtist];

        return nameOfArtist.Invoke(idArtist);
    }
}