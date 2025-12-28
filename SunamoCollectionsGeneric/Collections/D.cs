// variables names: ok
namespace SunamoCollectionsGeneric.Collections;

// EN: Variable names have been checked and replaced with self-descriptive names
// CZ: Názvy proměnných byly zkontrolovány a nahrazeny samopopisnými názvy
/// <summary>
///     Must be IEnumerable, not IList
/// </summary>
/// <typeparam name="T"></typeparam>
/// <typeparam name="U"></typeparam>
public class D<T, U> : ISunamoDictionary<T, U>, IEnumerable, IDictionary<T, U>
{
    private static Type DictionaryType = typeof(D<T, U>);

    public Action CallWhenIsZeroElements { get; set; }
    private readonly Dictionary<T, U> dictionary = new();

    IEnumerator IEnumerable.GetEnumerator()
    {
        return dictionary.GetEnumerator();
    }

    public U this[T key]
    {
        get
        {
            if (CallWhenIsZeroElements != null)
                if (Count == 0)
                    CallWhenIsZeroElements.Invoke();
            return dictionary[key];
        }
        set
        {
            ContainsV(value);

            dictionary[key] = value;
        }
    }

    public ICollection<T> Keys => dictionary.Keys;

    public ICollection<U> Values => dictionary.Values;

    public int Count => dictionary.Count;

    public bool IsReadOnly => false;

    public void Add(T key, U value)
    {
        ContainsV(value);

        dictionary.Add(key, value);
    }

    public void Add(KeyValuePair<T, U> item)
    {
        ContainsV(item.Value);
        dictionary.Add(item.Key, item.Value);
    }

    public void Clear()
    {
#if DEBUG
        OnRemove();
#endif

        dictionary.Clear();
    }

    public bool Contains(KeyValuePair<T, U> item)
    {
        return dictionary.Contains(item);
    }

    public bool ContainsKey(T key)
    {
        return dictionary.ContainsKey(key);
    }

    public void CopyTo(KeyValuePair<T, U>[] array, int arrayIndex)
    {
        ThrowEx.NotImplementedMethod();
        //DictionaryHelper.CopyTo<T, U>(d, array, arrayIndex);
    }

    public IEnumerator<KeyValuePair<T, U>> GetEnumerator()
    {
        return dictionary.GetEnumerator();
    }

    public bool Remove(T key)
    {
#if DEBUG
        OnRemove();
#endif
        return dictionary.Remove(key);
    }

    public bool Remove(KeyValuePair<T, U> item)
    {
#if DEBUG
        OnRemove();
#endif
        return dictionary.Remove(item.Key);
    }

    public bool TryGetValue(T key, out U value)
    {
        return dictionary.TryGetValue(key, out value);
    }

    private void ContainsV(U value)
    {
#if DEBUG
        if (value.ToString().Contains(checkForContains))
        {
        }
#endif
    }
#if DEBUG
    private const string checkForContains = "ccc_netcore31";

    private void OnRemove()
    {
        Debugger.Break();
    }
#endif
}