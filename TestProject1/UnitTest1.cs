
using ConsoleApp1;
using Xunit;

namespace TestProject1;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {
        var expectedOne = 1;

        var res = Program.SomeMethod();
        
        Assert.Equal(expectedOne, res);
    }
}