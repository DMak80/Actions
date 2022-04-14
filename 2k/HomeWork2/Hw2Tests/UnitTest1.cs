using Hw2;
using Xunit;

namespace Hw2Tests;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {
        var expected = 5;
        var result = Program.GetFive();
        Assert.Equal(expected, result);
    }
}