namespace SunamoCollectionsGeneric.Collections;

public class BadGoodCollection<T>
{
    public List<T> Bad { get; set; } = new();
    public List<T> Good { get; set; } = new();
}
