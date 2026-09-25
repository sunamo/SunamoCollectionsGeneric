namespace SunamoCollectionsGeneric.Collections;

public class ResolvedDictionary<T, U> where T : notnull
{
    public Dictionary<T, U> Dictionary { get; set; } = new();

    public U Get(T key, Func<T, U> resolver)
    {
        if (Dictionary.ContainsKey(key)) return Dictionary[key];

        return resolver.Invoke(key);
    }
}
