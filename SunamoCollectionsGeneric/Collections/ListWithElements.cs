namespace SunamoCollectionsGeneric.Collections;

public class ListWithElements<T> : L<T>
{
    public ListWithElements(int count)
    {
        for (var i = 0; i < count; i++) Add(default);
    }
}