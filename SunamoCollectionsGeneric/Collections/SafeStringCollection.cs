// variables names: ok
// EN: Variable names have been checked and replaced with self-descriptive names
// CZ: Názvy proměnných byly zkontrolovány a nahrazeny samopopisnými názvy
namespace SunamoCollectionsGeneric.Collections;

public class SafeStringCollection
{
    private readonly char _replaceFor;
    private readonly List<char> _unallowedChars;
    public List<string> Items = new();

    public SafeStringCollection(List<char> unallowedChars, char replaceFor)
    {
        _unallowedChars = unallowedChars;
        _replaceFor = replaceFor;
    }

    public void Add(string text)
    {
        var stringBuilder = new StringBuilder();
        foreach (var item in text)
        {
            var character = item;

            if (_unallowedChars.Contains(item)) character = _replaceFor;

            stringBuilder.Append(character);
        }

        Items.Add(stringBuilder.ToString());
    }
}