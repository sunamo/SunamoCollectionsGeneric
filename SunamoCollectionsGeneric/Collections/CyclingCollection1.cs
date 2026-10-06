namespace SunamoCollectionsGeneric.Collections;

public partial class CyclingCollection<T>
{
    public T Next(int count)
    {
        if (count > Items.Count)
            return GetIteration;
        index += count;
        var currentIndex = index;
        if (currentIndex > Items.Count)
        {
            var newIndex = currentIndex - Items.Count;
            index = newIndex;
        }
        else if (currentIndex > 0)
        {
            index = currentIndex;
        }

        OnChange();
        return GetIteration;
    }

    public void OnChange()
    {
        Change?.Invoke();
    }

    public event Action<string>? NewStatus;

    public void OnNewStatus(string text, params string[] parameters)
    {
        NewStatus?.Invoke(string.Format(text, parameters));
    }
}
