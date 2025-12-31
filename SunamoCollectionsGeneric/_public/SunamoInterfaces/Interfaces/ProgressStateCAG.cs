namespace SunamoCollectionsGeneric._public.SunamoInterfaces.Interfaces;

public class ProgressStateCAG
{
    public int Count { get; set; }
    public bool IsRegistered { get; set; }

    public void Init(Action<int> overallSongs, Action<int> anotherSong, Action writeProgressBarEnd)
    {
        IsRegistered = true;
        this.AnotherSong += anotherSong;
        this.OverallSongs += overallSongs;
        this.WriteProgressBarEnd += writeProgressBarEnd;
    }

    public event Action<int> AnotherSong;
    public event Action<int> OverallSongs;
    public event Action WriteProgressBarEnd;

    public void OnAnotherSong()
    {
        Count++;
        OnAnotherSong(Count);
    }

    public void OnAnotherSong(int count)
    {
        AnotherSong(count);
    }

    public void OnOverallSongs(int totalCount)
    {
        Count = 0;
        OverallSongs(totalCount);
    }

    public void OnWriteProgressBarEnd()
    {
        WriteProgressBarEnd();
    }
}