using System.Diagnostics;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace Hw9Tests;

public class CalculationTimeTests: IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient _client;

    public CalculationTimeTests(WebApplicationFactory<Program> fixture)
    {
        _client = fixture.CreateClient();
    }
    
    [Theory]
    [InlineData("2 + 3 + 4 + 6", 3000, 4000)]
    [InlineData("(2 * 3 + 3 * 3) * (5 / 5 + 6 / 6)", 3000, 4000)]
    [InlineData("(2 + 3) / 12 * 7 + 8 * 9", 4000, 5000)]
    private async Task CalculatorController_ParallelTest(string expression, long minExpectedTime, long maxExpectedTime)
    {
        var executionTime = await GetRequestExecutionTime(expression);
        Assert.True(executionTime >= minExpectedTime);
        Assert.True(executionTime <= maxExpectedTime);
    }
    
    private async Task<long> GetRequestExecutionTime(string expression)
    {
        var watch = Stopwatch.StartNew();
        await _client.PostCalculateExpressionAsync(expression);
        watch.Stop();
        return watch.ElapsedMilliseconds;
    }
}