using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace Hw10Tests;

public class CalculationTimeTests: IClassFixture<TestApplicationFactory>
{
    private readonly HttpClient _client;

    public CalculationTimeTests(TestApplicationFactory fixture)
    {
        _client = fixture.CreateClient();
    }
    
    [Theory]
    [InlineData("2 + 3 + 4 + 6", 3000, 4000)]
    [InlineData("(2 * 3 + 3 * 3) * (5 / 5 + 6 / 6)", 3000, 4000)]
    [InlineData("(2 + 3) / 12 * 7 + 8 * 9", 4000, 5000)]
    private async Task Calculate_ParallelTest(string expression, long minExpectedTime, long maxExpectedTime)
    {
        var executionTime = await GetRequestExecutionTime(expression);
        Assert.True(executionTime >= minExpectedTime);
        Assert.True(executionTime <= maxExpectedTime);
    }
    
    [Theory]
    [InlineData("1 + 1 + 1 + 1")]
    [InlineData("2 * (3 + 2) / 2")]
    [InlineData("2 * 3 / 1 * 5 * 6")]
    private async Task Calculate_CacheTest(string expression)
    {
        await GetRequestExecutionTime(expression);
        var secondCalculationTime = await GetRequestExecutionTime(expression);
        Assert.True(secondCalculationTime <= 2000);
    }
    
    private async Task<long> GetRequestExecutionTime(string expression)
    {
        var watch = Stopwatch.StartNew();
        var response = await _client.PostCalculateExpressionAsync(expression);
        watch.Stop();
        response.EnsureSuccessStatusCode();
        return watch.ElapsedMilliseconds;
    }
}