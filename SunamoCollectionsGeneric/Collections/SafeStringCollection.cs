namespace SunamoCollectionsGeneric.Collections;

public class SafeStringCollection
{
    private readonly char replacementCharacter;
    private readonly List<char> unallowedChars;

    public List<string> Items { get; set; } = new();

    public SafeStringCollection(List<char> unallowedChars, char replacementCharacter)
    {
        this.unallowedChars = unallowedChars;
        this.replacementCharacter = replacementCharacter;
    }

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
