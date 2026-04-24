namespace SunamoCollectionsGeneric.Collections;

/// <summary>
/// A string collection that replaces unallowed characters with a safe replacement character
/// </summary>
public class SafeStringCollection
{
    private readonly char replacementCharacter;
    private readonly List<char> unallowedChars;

    /// <summary>
    /// Gets or sets the list of sanitized string items
    /// </summary>
    public List<string> Items { get; set; } = new();

    /// <summary>
    /// Initializes a new instance with characters to replace and the replacement character
    /// </summary>
    /// <param name="unallowedChars">List of characters that are not allowed</param>
    /// <param name="replacementCharacter">The character to replace unallowed characters with</param>
    public SafeStringCollection(List<char> unallowedChars, char replacementCharacter)
    {
        this.unallowedChars = unallowedChars;
        this.replacementCharacter = replacementCharacter;
    }

    /// <summary>
    /// Adds a string to the collection after replacing all unallowed characters
    /// </summary>
    /// <param name="text">The text to add</param>
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