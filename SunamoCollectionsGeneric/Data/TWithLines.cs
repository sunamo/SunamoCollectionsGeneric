namespace SunamoCollectionsGeneric.Data;

public class TWithLines<T>
{
    public L<string> Lines { get; set; } = null;
    public T Value { get; set; } = default;
}