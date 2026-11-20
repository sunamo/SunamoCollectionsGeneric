namespace SunamoCollectionsGeneric.Collections;

/// <summary>
/// Represents the joiner t type.
/// </summary>
public class Joiner<T>
{
    private readonly string joinWith;
    private readonly List<T> list;

    /// <summary>
    /// Initializes a new instance of the joiner class.
    /// </summary>
    public Joiner() : this(",")
    {
    }

    /// <summary>
    /// Initializes a new instance of the joiner class.
    /// </summary>
    /// <param name="joinWith">The join with.</param>
    /// <param name="capacity">The capacity.</param>
    public Joiner(string joinWith, int capacity = 5)
    {
        this.joinWith = joinWith;
        list = new List<T>(capacity);
    }

    /// <summary>
    /// To string.
    /// </summary>
    /// <returns>The to string result.</returns>
    public override string ToString()
    {
        return string.Join(joinWith, list);
    }

    /// <summary>
    /// Add.
    /// </summary>
    /// <param name="value">The value.</param>
    public void Add(T value)
    {
        list.Add(value);
    }
}
