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