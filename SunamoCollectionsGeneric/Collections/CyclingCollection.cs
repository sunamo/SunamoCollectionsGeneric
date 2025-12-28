// variables names: ok
namespace SunamoCollectionsGeneric.Collections;

// EN: Variable names have been checked and replaced with self-descriptive names
// CZ: Názvy proměnných byly zkontrolovány a nahrazeny samopopisnými názvy
/// <summary>
/// </summary>
public partial class CyclingCollection<T>
{
    public static string XUnableToLoadElementAddSomeAndTryAgain = "UnableToLoadElementAddSomeAndTryAgain";
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
        get => _MakesSpaces;
        set
        {
            _MakesSpaces = value;
            OnChange();
        }
    }

    public T GetIterationSimple
    {
        get
        {
            if (Items.Count == 0)
                return default;
            return Items[index];
        }
    }

    /// <summary>
    ///     If can't be obtained, try to get element previous or next.
    /// </summary>
    public T GetIretation
    {
        get
        {
            T result = default;
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

    public void Add(T item)
    {
        Items.Add(item);
        _index++;
        OnChange();
    }

    public void AddRange(IList<T> items)
    {
        //t.AddRange(items);
        foreach (var item in items)
        {
            Items.Add(item);
            _index++;
        }

        OnChange();
    }

    public void Clear()
    {
        Items.Clear();
        _index = 0;
        OnChange();
    }

    public T SetIretation(int newIndex)
    {
        index = ValidateIndex(newIndex);
        OnChange();
        return GetIretation;
    }

    private int ValidateIndex(int newIndex)
    {
        if (newIndex < 0)
            newIndex = Items.Count - 1;
        else if (newIndex >= Items.Count)
            newIndex = 0;
        return newIndex;
    }

    public void SetIretationWithoutEvent(int newIndex)
    {
        index = newIndex;
    }

    public override string ToString()
    {
        var stringBuilder = new StringBuilder();
        stringBuilder.Append(ActualIndex + 1);
        if (_MakesSpaces)
            stringBuilder.Append(" ");
        stringBuilder.Append("/");
        if (_MakesSpaces)
            stringBuilder.Append(" ");
        stringBuilder.Append(Items.Count.ToString());
        return stringBuilder.ToString();
    }

    public void ReplaceOnce(T oldItem, T newItem)
    {
        var itemIndex = Items.IndexOf(oldItem);
        Items.RemoveAt(itemIndex);
        Items.Insert(itemIndex, newItem);
    }

    public List<T> Items { get; set; } = new();
    private int _index;
    private int index
    {
        get
        {
            if (_index < 0)
                _index = 0;
            else if (_index > Items.Count - 1)
                _index = Items.Count - 1;
            return _index;
        }

        set
        {
            if (value < 0)
                value = 0;
            _index = value;
        }
    }

    /// <summary>
    ///     Whether make space in formatting actual showing
    /// </summary>
    private bool _MakesSpaces;
    public event Action Change;
    private EventArgs _ea = EventArgs.Empty;
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
        //OnChange();
        }
        else
        {
            if (index != 0)
                index--;
        //OnChange();
        }

        OnChange();
        return GetIretation;
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
        //OnChange();
        }
        else
        {
            if (index != Items.Count - 1)
                index++;
        //OnChange();
        }

        OnChange();
        return GetIretation;
    }

    public T Before(int count)
    {
        if (count > Items.Count)
            return GetIretation;
        index -= count;
        var currentIndex = index;
        if (currentIndex == 0)
        {
        }
        else if (currentIndex < 0)
        {
            var amountToSubtract = Math.Abs(currentIndex);
            var newIndex = Items.Count - amountToSubtract;
            index = newIndex;
        }
        else
        {
            //index-= count;
            index = currentIndex;
        }

        OnChange();
        return GetIretation;
    }
}