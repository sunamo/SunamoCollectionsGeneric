// EN: Variable names have been checked and replaced with self-descriptive names
// CZ: Názvy proměnných byly zkontrolovány a nahrazeny samopopisnými názvy
namespace SunamoCollectionsGeneric._sunamo.SunamoInterfaces.Interfaces;

internal interface ISunamoDictionary<T, U>
{
    U this[T key] { get; set; }
    ICollection<T> Keys { get; }
    ICollection<U> Values { get; }
    int Count { get; }
    bool IsReadOnly { get; }
    void Add(T key, U value);
    void Add(KeyValuePair<T, U> item);
    void Clear();
    bool Contains(KeyValuePair<T, U> item);
    bool ContainsKey(T key);
    void CopyTo(KeyValuePair<T, U>[] array, int arrayIndex);
    IEnumerator<KeyValuePair<T, U>> GetEnumerator();
    bool Remove(T key);
    bool Remove(KeyValuePair<T, U> item);
    bool TryGetValue(T key, out U value);
}