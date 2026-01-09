// variables names: ok
namespace SunamoCollectionsGeneric._public.SunamoInterfaces.Interfaces;

/// <summary>
/// Represents progress state for Collection processing operations.
/// </summary>
public class ProgressStateCAG
{
    /// <summary>
    /// Gets or sets the current count of processed items.
    /// </summary>
    public int Count { get; set; }

    /// <summary>
    /// Gets or sets whether the progress state is registered with callbacks.
    /// </summary>
    public bool IsRegistered { get; set; }

    /// <summary>
    /// Initializes the progress state with callbacks for overall items count, item processing, and completion.
    /// </summary>
    /// <param name="overallItems">Callback when overall count of items is determined.</param>
    /// <param name="anotherItem">Callback when another item is processed.</param>
    /// <param name="writeProgressBarEnd">Callback when processing is complete.</param>
    public void Init(Action<int> overallItems, Action<int> anotherItem, Action writeProgressBarEnd)
    {
        IsRegistered = true;
        this.AnotherItem += anotherItem;
        this.OverallItems += overallItems;
        this.WriteProgressBarEnd += writeProgressBarEnd;
    }

    /// <summary>
    /// Event raised when another item is processed.
    /// </summary>
    public event Action<int> AnotherItem;

    /// <summary>
    /// Event raised when the overall number of items is determined.
    /// </summary>
    public event Action<int> OverallItems;

    /// <summary>
    /// Event raised when progress bar should end.
    /// </summary>
    public event Action WriteProgressBarEnd;

    /// <summary>
    /// Triggers the AnotherItem event with an auto-incremented count.
    /// </summary>
    public void OnAnotherItem()
    {
        Count++;
        OnAnotherItem(Count);
    }

    /// <summary>
    /// Triggers the AnotherItem event with the specified count.
    /// </summary>
    /// <param name="count">The count of items processed.</param>
    public void OnAnotherItem(int count)
    {
        AnotherItem(count);
    }

    /// <summary>
    /// Triggers the OverallItems event and resets the count.
    /// </summary>
    /// <param name="totalCount">The total number of items to be processed.</param>
    public void OnOverallItems(int totalCount)
    {
        Count = 0;
        OverallItems(totalCount);
    }

    /// <summary>
    /// Triggers the WriteProgressBarEnd event.
    /// </summary>
    public void OnWriteProgressBarEnd()
    {
        WriteProgressBarEnd();
    }
}