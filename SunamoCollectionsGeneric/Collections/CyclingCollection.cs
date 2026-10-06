namespace SunamoCollectionsGeneric.Collections;

public partial class CyclingCollection<T>
{
    public const string XUnableToLoadElementAddSomeAndTryAgain = "UnableToLoadElementAddSomeAndTryAgain";

    public bool IsGoingBack { get; set; }

    public CyclingCollection(bool isCycling)
    {
        this.IsCycling = isCycling;
    }

    public CyclingCollection()
    {
    }

    public int ActualIndex => index;

    public bool MakesSpaces
    {
        get => makesSpaces;
        set
        {
            makesSpaces = value;
            OnChange();
        }
    }

    public T GetIterationSimple
    {
        get
        {
            if (Items.Count == 0)
                return default!;
            return Items[index];
        }
    }

    // If can't be obtained, try to get element previous or next.
    public T GetIteration
    {
        get
        {
            T result = default!;
            var absoluteIndex = Math.Abs(index);
            if (Items.Count > absoluteIndex && Items.Count >= absoluteIndex)
            {
                result = Items[absoluteIndex];
            }
            else
            {
                absoluteIndex = Math.Abs(++index);
                if (Items.Count > absoluteIndex && Items.Count >= absoluteIndex)
                {
                    result = Items[absoluteIndex];
                }
                else
                {
                    index--;
                    absoluteIndex = Math.Abs(--index);
                    if (Items.Count > absoluteIndex && Items.Count >= absoluteIndex)
                    {
                        result = Items[absoluteIndex];
                    }
                    else
                    {
                        if (Items.Count > 0)
                            result = Items[0];
                        else
                            OnNewStatus(XUnableToLoadElementAddSomeAndTryAgain);
                    }
                }
            }

            return result;
        }
    }

    public void Add(T value)
    {
        Items.Add(value);
        indexBackingField++;
        OnChange();
    }

    public void AddRange(IList<T> list)
    {
        foreach (var item in list)
        {
            Items.Add(item);
            indexBackingField++;
        }

        OnChange();
    }

    public void Clear()
    {
        Items.Clear();
        indexBackingField = 0;
        OnChange();
    }

    public T SetIteration(int newIndex)
    {
        index = ValidateIndex(newIndex);
        OnChange();
        return GetIteration;
    }

    private int ValidateIndex(int newIndex)
    {
        if (newIndex < 0)
            newIndex = Items.Count - 1;
        else if (newIndex >= Items.Count)
            newIndex = 0;
        return newIndex;
    }

    public void SetIterationWithoutEvent(int newIndex)
    {
        index = newIndex;
    }

    public override string ToString()
    {
        var stringBuilder = new StringBuilder();
        stringBuilder.Append(ActualIndex + 1);
        if (makesSpaces)
            stringBuilder.Append(" ");
        stringBuilder.Append("/");
        if (makesSpaces)
            stringBuilder.Append(" ");
        stringBuilder.Append(Items.Count.ToString());
        return stringBuilder.ToString();
    }

    public void ReplaceOnce(T oldValue, T newValue)
    {
        var foundIndex = Items.IndexOf(oldValue);
        Items.RemoveAt(foundIndex);
        Items.Insert(foundIndex, newValue);
    }

    public List<T> Items { get; set; } = new();
    private int indexBackingField;
    private int index
    {
        get
        {
            if (indexBackingField < 0)
                indexBackingField = 0;
            else if (indexBackingField > Items.Count - 1)
                indexBackingField = Items.Count - 1;
            return indexBackingField;
        }

        set
        {
            if (value < 0)
                value = 0;
            indexBackingField = value;
        }
    }

    private bool makesSpaces;

    public event Action? Change;

    public bool IsCycling { get; set; } = true;

    public T Before()
    {
        IsGoingBack = true;
        if (IsCycling)
        {
            if (index == 0)
                index = Items.Count - 1;
            else
                index--;
        }
        else
        {
            if (index != 0)
                index--;
        }

        OnChange();
        return GetIteration;
    }

    public T Next()
    {
        IsGoingBack = false;
        if (IsCycling)
        {
            if (index == Items.Count - 1)
                index = 0;
            else
                index++;
        }
        else
        {
            if (index != Items.Count - 1)
                index++;
        }

        OnChange();
        return GetIteration;
    }

    public T Before(int count)
    {
        if (count > Items.Count)
            return GetIteration;
        index -= count;
        var currentIndex = index;
        if (currentIndex < 0)
        {
            var amountToSubtract = Math.Abs(currentIndex);
            var newIndex = Items.Count - amountToSubtract;
            index = newIndex;
        }
        else if (currentIndex > 0)
        {
            index = currentIndex;
        }

        OnChange();
        return GetIteration;
    }
}
