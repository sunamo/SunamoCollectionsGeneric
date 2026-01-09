// variables names: ok
namespace SunamoCollectionsGeneric.Collections;

/// <summary>
/// Partial class continuation for CyclingCollection
/// </summary>
public partial class CyclingCollection<T>
{
    /// <summary>
    /// Moves forward by the specified number of items
    /// </summary>
    /// <param name="count">The number of items to move forward</param>
    /// <returns>The item at the new position</returns>
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
            // Calculate how much to shift in the new cycle
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

    /// <summary>
    /// Triggers the Change event
    /// </summary>
    public void OnChange()
    {
        if (Change != null)
            Change();
    }

    /// <summary>
    /// Event raised when a new status message is generated
    /// </summary>
    public event Action<string> NewStatus;

    /// <summary>
    /// Triggers the NewStatus event with a formatted message
    /// </summary>
    /// <param name="text">The format string</param>
    /// <param name="p">The format parameters</param>
    public void OnNewStatus(string text, params string[] p)
    {
        if (NewStatus != null)
            NewStatus(string.Format(text, p));
    }
}