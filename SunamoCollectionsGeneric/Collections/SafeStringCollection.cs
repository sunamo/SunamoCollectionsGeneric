namespace SunamoCollectionsGeneric.Collections;

public class SafeStringCollection
{
    private readonly char _replaceFor;
    private readonly List<char> _unallowedChars;
    public List<string> safeStringCollection = new();

    public SafeStringCollection(List<char> unallowedChars, char replaceFor)
    {
        _unallowedChars = unallowedChars;
        _replaceFor = replaceFor;
    }

    public void Add(string s)
    {
        var stringBuilder = new StringBuilder();
        foreach (var item in s)
        {
            var letter = item;

            if (_unallowedChars.Contains(item)) letter = _replaceFor;

            stringBuilder.Append(letter);
        }

        safeStringCollection.Add(stringBuilder.ToString());
    }
}