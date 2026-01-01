namespace SunamoCollectionsGeneric.Tests;

/// <summary>
/// Tests for CAG (Collection Array Generic) utility class.
/// </summary>
public class CAGTests
{
    /// <summary>
    /// Tests the CompareList method functionality.
    /// </summary>
    [Fact]
    public void CompareListTest()
    {
        var both = CAG.CompareList(new List<string>(["a", "c"]), new List<string>(["a", "d"]));
    }
}