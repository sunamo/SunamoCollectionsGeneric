namespace SunamoCollectionsGeneric.Tests;

public class CAGTests
{
    [Fact]
    public void CompareListTest()
    {
        var both = CAG.CompareList(new List<string>(["a", "c"]), new List<string>(["a", "d"]));
    }
}