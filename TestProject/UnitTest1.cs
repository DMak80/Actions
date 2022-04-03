
using TestConsoleApp;
using Xunit;

namespace TestProject;

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