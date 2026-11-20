namespace SunamoCollectionsGeneric.Collections;

public partial class CyclingCollection<T>
{
    /// <summary>
    /// Next.
    /// </summary>
    /// <param name="count">The count.</param>
    /// <returns>The next result.</returns>
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

    /// <summary>
    /// On change.
    /// </summary>
    public void OnChange()
    {
        Change?.Invoke();
    }

    /// <summary>
    /// The new status.
    /// </summary>
    public event Action<string>? NewStatus;

    /// <summary>
    /// On new status.
    /// </summary>
    /// <param name="text">The text.</param>
    /// <param name="parameters">The parameters.</param>
    /// <returns>The on new status result.</returns>
    public void OnNewStatus(string text, params string[] parameters)
    {
        NewStatus?.Invoke(string.Format(text, parameters));
    }
}
