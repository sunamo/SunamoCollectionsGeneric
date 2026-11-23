namespace SunamoCollectionsGeneric.Collections;

/// <summary>
/// Represents the cycling collection t type.
/// </summary>
public partial class CyclingCollection<T>
{
    /// <summary>
    /// The x unable to load element add some and try again constant.
    /// </summary>
    public const string XUnableToLoadElementAddSomeAndTryAgain = "UnableToLoadElementAddSomeAndTryAgain";

    /// <summary>
    /// Gets or sets the is going back.
    /// </summary>
    public bool IsGoingBack { get; set; }

    /// <summary>
    /// Cycling collection.
    /// </summary>
    /// <param name="isCycling">The is cycling.</param>
    /// <returns>The cycling collection result.</returns>
    public CyclingCollection(bool isCycling)
    {
        this.IsCycling = isCycling;
    }

    /// <summary>
    /// Initializes a new instance of the cycling collection class.
    /// </summary>
    /// <param name="isCycling">The is cycling.</param>
    public CyclingCollection()
    {
    }

    /// <summary>
    /// Gets the actual index.
    /// </summary>
    public int ActualIndex => index;

    /// <summary>
    /// The makes spaces.
    /// </summary>
    public bool MakesSpaces
    {
        get => makesSpaces;
        set
        {
            makesSpaces = value;
            OnChange();
        }
    }

    /// <summary>
    /// The get iteration simple.
    /// </summary>
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
    /// <summary>
    /// The get iteration.
    /// </summary>
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

    /// <summary>
    /// Initializes a new instance of the add class.
    /// </summary>
    /// <param name=">">The &gt;.</param>
    public void Add(T value)
    {
        Items.Add(value);
        indexBackingField++;
        OnChange();
    }

    /// <summary>
    /// Add range.
    /// </summary>
    /// <param name="XUnableToLoadElementAddSomeAndTryAgain">The x unable to load element add some and try again.</param>
    /// <returns>The add range result.</returns>
    public void AddRange(IList<T> list)
    {
        foreach (var item in list)
        {
            Items.Add(item);
            indexBackingField++;
        }

        OnChange();
    }

    /// <summary>
    /// Clear.
    /// </summary>
    /// <param name="value">The value.</param>
    public void Clear()
    {
        Items.Clear();
        indexBackingField = 0;
        OnChange();
    }

    /// <summary>
    /// Set iteration.
    /// </summary>
    /// <param name="list">The list.</param>
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

    /// <summary>
    /// Set iteration without event.
    /// </summary>
    /// <param name="newIndex">The new index.</param>
    /// <returns>The set iteration without event result.</returns>
    public void SetIterationWithoutEvent(int newIndex)
    {
        index = newIndex;
    }

    /// <summary>
    /// Initializes a new instance of the to string class.
    /// </summary>
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

    /// <summary>
    /// Replace once.
    /// </summary>
    /// <param name="newIndex">The new index.</param>
    public void ReplaceOnce(T oldValue, T newValue)
    {
        var foundIndex = Items.IndexOf(oldValue);
        Items.RemoveAt(foundIndex);
        Items.Insert(foundIndex, newValue);
    }

    /// <summary>
    /// Gets or sets the items.
    /// </summary>
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

    /// <summary>
    /// The change.
    /// </summary>
    public event Action? Change;

    /// <summary>
    /// Gets or sets the is cycling.
    /// </summary>
    public bool IsCycling { get; set; } = true;

    /// <summary>
    /// Initializes a new instance of the before class.
    /// </summary>
    /// <param name="0">The 0.</param>
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

    /// <summary>
    /// Next.
    /// </summary>
    /// <returns>The next result.</returns>
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

    /// <summary>
    /// Before.
    /// </summary>
    /// <returns>The before result.</returns>
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
