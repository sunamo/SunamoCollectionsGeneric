// EN: Variable names have been checked and replaced with self-descriptive names
// CZ: Názvy proměnných byly zkontrolovány a nahrazeny samopopisnými názvy
namespace SunamoCollectionsGeneric.Collections;

public class SunamoDictionary<T, U> : Dictionary<T, U>
{
    public int CountOfValueNot(U u)
    {
        var vr = 0;
        foreach (var item in this)
            if (!EqualityComparer<U>.Default.Equals(item.Value, u))
                vr++;
        return vr;
    }

    public bool AnyValue(U u)
    {
        foreach (var item in this)
            if (EqualityComparer<U>.Default.Equals(item.Value, u))
                return true;
        return false;
    }

    public int CountOfValue(U u)
    {
        var vr = 0;
        foreach (var item in this)
            if (EqualityComparer<U>.Default.Equals(item.Value, u))
                vr++;
        return vr;
    }
}