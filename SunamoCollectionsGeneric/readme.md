# SunamoCollectionsGeneric

A .NET library providing utility methods and specialized collection types for working with generic collections.

## Features

- **CAG** - Static helper class with utility methods for lists, arrays, and two-dimensional arrays (compare, deduplicate, search, convert)
- **CyclingCollection** - Collection with forward/backward navigation and optional cycling behavior
- **DictionaryWithList** - Dictionary backed by a list, maintaining insertion order
- **DictionarySort / SunamoDictionarySort** - Dictionary implementations with sorting capabilities for keys and values
- **SunamoHashSetWithoutDuplicates** - HashSet that tracks and reports duplicate items during addition
- **RefreshingList** - List that automatically refreshes from a source list when it becomes empty
- **UniqueTableInWhole** - Table structure with row/column uniqueness constraints
- **Joiner** - Helper for building a string by joining items with a separator
- **SafeStringCollection** - String collection that sanitizes entries by replacing disallowed characters

## Target Frameworks

`net10.0`, `net9.0`, `net8.0`

## Links

- [NuGet](https://www.nuget.org/profiles/sunamo)
- [GitHub](https://github.com/sunamo/PlatformIndependentNuGetPackages)
- [Developer site](https://sunamo.cz)

For feature requests, bug reports, or other inquiries: [Email](mailto:radek.jancik@sunamo.cz) or via GitHub Issues
