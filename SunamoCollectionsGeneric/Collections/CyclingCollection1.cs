namespace SunamoCollectionsGeneric.Collections;

// EN: Variable names have been checked and replaced with self-descriptive names
// CZ: Názvy proměnných byly zkontrolovány a nahrazeny samopopisnými názvy
/// <summary>
/// </summary>
public partial class CyclingCollection<T>
{
    public T Next(int pocet)
    {
        if (pocet > c.Count)
            return GetIretation;
        index += pocet;
        var dex = index;
        if (dex == 0)
        {
        }
        else if (dex > c.Count)
        {
            // Zjistim o kolik a tolik posunu i v novem
            var vNovem = dex - c.Count;
            index = vNovem;
        }
        else
        {
            //
            index = dex;
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