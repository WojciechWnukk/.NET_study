namespace Lab2.Test;

public class UnitTest1
{
    [Fact]
    public void
    FormatUsdPrice_ProperFormat_ShouldReturnProperString()
    {
        var data = 0.05;
        var result = MyFormatter.FormatUsdPrice(data);
        Assert.StartsWith("$0.05", result);
        Assert.Contains("$0.05", result);
    }

}