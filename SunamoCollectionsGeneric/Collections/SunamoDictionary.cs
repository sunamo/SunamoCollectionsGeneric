// variables names: ok
namespace SunamoCollectionsGeneric.Collections;

// EN: Variable names have been checked and replaced with self-descriptive names
// CZ: Názvy proměnných byly zkontrolovány a nahrazeny samopopisnými názvy
public class SunamoDictionary<T, U> : Dictionary<T, U>
{
    public int CountOfValueNot(U value)
    {
        var count = 0;
        foreach (var item in this)
            if (!EqualityComparer<U>.Default.Equals(item.Value, value))
                count++;
        return count;
    }

    public bool AnyValue(U value)
    {
        foreach (var item in this)
            if (EqualityComparer<U>.Default.Equals(item.Value, value))
                return true;
        return false;
    }

    public int CountOfValue(U value)
    {
        var count = 0;
        foreach (var item in this)
            if (EqualityComparer<U>.Default.Equals(item.Value, value))
                count++;
        return count;
    }
}