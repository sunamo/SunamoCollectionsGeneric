namespace SunamoCollectionsGeneric._public.SunamoInterfaces.Interfaces;

public class ProgressStateCAG
{
    public int Count { get; set; }

    public bool IsRegistered { get; set; }

    public void Init(Action<int> overallItems, Action<int> anotherItem, Action writeProgressBarEnd)
    {
        IsRegistered = true;
        this.AnotherItem += anotherItem;
        this.OverallItems += overallItems;
        this.WriteProgressBarEnd += writeProgressBarEnd;
    }

    public event Action<int>? AnotherItem;

    public event Action<int>? OverallItems;

    public event Action? WriteProgressBarEnd;

    public void OnAnotherItem()
    {
        Count++;
        OnAnotherItem(Count);
    }

    public void OnAnotherItem(int count)
    {
        AnotherItem?.Invoke(count);
    }

    public void OnOverallItems(int totalCount)
    {
        Count = 0;
        OverallItems?.Invoke(totalCount);
    }

    public void OnWriteProgressBarEnd()
    {
        WriteProgressBarEnd?.Invoke();
    }
}
