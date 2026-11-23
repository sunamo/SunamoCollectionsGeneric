namespace SunamoCollectionsGeneric.Collections;

/// <summary>
/// Represents the resolved dictionary t u type.
/// </summary>
public class ResolvedDictionary<T, U> where T : notnull
{
    /// <summary>
    /// Gets or sets the dictionary.
    /// </summary>
    public Dictionary<T, U> Dictionary { get; set; } = new();

    /// <summary>
    /// Get.
    /// </summary>
    /// <returns>The get result.</returns>
    public U Get(T key, Func<T, U> resolver)
    {
        if (Dictionary.ContainsKey(key)) return Dictionary[key];

        return resolver.Invoke(key);
    }
}
