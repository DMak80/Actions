using ActionsTestApp;
using Xunit;

namespace TestProject1;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {
        var arrangeOne = 1;

        var res = Program.GetOne();
        
        Assert.Equal(arrangeOne, res);
    }
}