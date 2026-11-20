namespace SunamoCollectionsGeneric.Collections;

/// <summary>
/// Represents the safe string collection type.
/// </summary>
public class SafeStringCollection
{
    private readonly char replacementCharacter;
    private readonly List<char> unallowedChars;

    /// <summary>
    /// Gets or sets the items.
    /// </summary>
    public List<string> Items { get; set; } = new();

    /// <summary>
    /// Safe string collection.
    /// </summary>
    /// <returns>The safe string collection result.</returns>
    public SafeStringCollection(List<char> unallowedChars, char replacementCharacter)
    {
        this.unallowedChars = unallowedChars;
        this.replacementCharacter = replacementCharacter;
    }

    /// <summary>
    /// Add.
    /// </summary>
    /// <param name="text">The text.</param>
    /// <returns>The add result.</returns>
    public void Add(string text)
    {
        var stringBuilder = new StringBuilder();
        foreach (var item in text)
        {
            var character = item;

            if (unallowedChars.Contains(item)) character = replacementCharacter;

            stringBuilder.Append(character);
        }

        Items.Add(stringBuilder.ToString());
    }
}
