namespace SunamoCollectionsGeneric.Collections;

/// <summary>
/// Dictionary that resolves values using a function when a key is not found
/// </summary>
/// <typeparam name="T">The type of keys</typeparam>
/// <typeparam name="U">The type of values</typeparam>
public class ResolvedDictionary<T, U>
{
    /// <summary>
    /// Gets or sets the underlying dictionary
    /// </summary>
    public Dictionary<T, U> Dictionary { get; set; } = new();

    /// <summary>
    /// Gets the value for the specified key, using the resolver function if the key is not found
    /// </summary>
    /// <param name="key">The key to look up</param>
    /// <param name="resolver">The function to resolve the value if key is not found</param>
    /// <returns>The value from the dictionary or the resolved value</returns>
    public U Get(T key, Func<T, U> resolver)
    {
        if (Dictionary.ContainsKey(key)) return Dictionary[key];

        return resolver.Invoke(key);
    }
}