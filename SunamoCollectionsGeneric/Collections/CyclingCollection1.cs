// variables names: ok
namespace SunamoCollectionsGeneric.Collections;

// EN: Variable names have been checked and replaced with self-descriptive names
// CZ: Názvy proměnných byly zkontrolovány a nahrazeny samopopisnými názvy
/// <summary>
/// </summary>
public partial class CyclingCollection<T>
{
    public T Next(int count)
    {
        if (count > Items.Count)
            return GetIretation;
        index += count;
        var currentIndex = index;
        if (currentIndex == 0)
        {
        }
        else if (currentIndex > Items.Count)
        {
            // Zjistim o kolik a tolik posunu i v novem
            var newIndex = currentIndex - Items.Count;
            index = newIndex;
        }
        else
        {
            //
            index = currentIndex;
        }

        OnChange();
        return GetIretation;
    }

    public void OnChange()
    {
        if (Change != null)
            Change();
    }

    public event Action<string> NewStatus;
    public void OnNewStatus(string text, params string[] p)
    {
        if (NewStatus != null)
            NewStatus(string.Format(text, p));
    }
}