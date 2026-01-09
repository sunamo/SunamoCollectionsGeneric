// variables names: ok
namespace SunamoCollectionsGeneric.Collections;

/// <summary>
/// Collection that supports cycling through items with forward and backward navigation
/// </summary>
/// <typeparam name="T">The type of elements in the collection</typeparam>
public partial class CyclingCollection<T>
{
    /// <summary>
    /// Error message for when unable to load element
    /// </summary>
    public static string XUnableToLoadElementAddSomeAndTryAgain = "UnableToLoadElementAddSomeAndTryAgain";

    /// <summary>
    /// Gets or sets whether the collection is currently navigating backwards
    /// </summary>
    public bool IsGoingBack { get; set; }

    /// <summary>
    /// Initializes a new instance with the specified cycling behavior
    /// </summary>
    /// <param name="isCycling">Whether to cycle back to the beginning when reaching the end</param>
    public CyclingCollection(bool isCycling)
    {
        this.IsCycling = isCycling;
    }

    /// <summary>
    /// Initializes a new instance of the CyclingCollection class
    /// </summary>
    public CyclingCollection()
    {
    }

    /// <summary>
    /// Gets the current index position in the collection
    /// </summary>
    public int ActualIndex => index;

    /// <summary>
    /// Gets or sets whether to include spaces in formatted output
    /// </summary>
    public bool MakesSpaces
    {
        get => _MakesSpaces;
        set
        {
            _MakesSpaces = value;
            OnChange();
        }
    }

    /// <summary>
    /// Gets the current item without error handling
    /// </summary>
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

    /// <summary>
    /// Adds an item to the collection
    /// </summary>
    /// <param name="item">The item to add</param>
    public void Add(T item)
    {
        Items.Add(item);
        _index++;
        OnChange();
    }

    /// <summary>
    /// Adds multiple items to the collection
    /// </summary>
    /// <param name="items">The items to add</param>
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

    /// <summary>
    /// Removes all items from the collection
    /// </summary>
    public void Clear()
    {
        Items.Clear();
        _index = 0;
        OnChange();
    }

    /// <summary>
    /// Sets the current iteration index to the specified value
    /// </summary>
    /// <param name="newIndex">The new index position</param>
    /// <returns>The item at the new index</returns>
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

    /// <summary>
    /// Sets the iteration index without triggering the Change event
    /// </summary>
    /// <param name="newIndex">The new index position</param>
    public void SetIretationWithoutEvent(int newIndex)
    {
        index = newIndex;
    }

    /// <summary>
    /// Returns a string representation showing current position and total count
    /// </summary>
    /// <returns>A string in the format "current/total"</returns>
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

    /// <summary>
    /// Replaces the first occurrence of an old item with a new item
    /// </summary>
    /// <param name="oldItem">The item to replace</param>
    /// <param name="newItem">The new item</param>
    public void ReplaceOnce(T oldItem, T newItem)
    {
        var itemIndex = Items.IndexOf(oldItem);
        Items.RemoveAt(itemIndex);
        Items.Insert(itemIndex, newItem);
    }

    /// <summary>
    /// Gets or sets the list of items in the collection
    /// </summary>
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
    /// Whether to make space in formatting the actual display.
    /// </summary>
    private bool _MakesSpaces;

    /// <summary>
    /// Event raised when the collection state changes
    /// </summary>
    public event Action Change;

    /// <summary>
    /// Gets or sets whether the collection cycles back to the beginning when reaching the end
    /// </summary>
    public bool IsCycling { get; set; } = true;

    /// <summary>
    /// Moves to the previous item in the collection
    /// </summary>
    /// <returns>The previous item</returns>
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

    /// <summary>
    /// Moves to the next item in the collection
    /// </summary>
    /// <returns>The next item</returns>
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

    /// <summary>
    /// Moves backward by the specified number of items
    /// </summary>
    /// <param name="count">The number of items to move backward</param>
    /// <returns>The item at the new position</returns>
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