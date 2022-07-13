using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace Hw8Tests;

public class IntegrationTests: IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient _client;
    private readonly string _url = "https://localhost:7008";

    public IntegrationTests(WebApplicationFactory<Program> fixture)
    {
        _client = fixture.CreateClient();
    }
    
    [Theory]
    [InlineData("9", "Plus", "4", "13")]
    [InlineData("1000", "Minus", "4.53", "995.47")]
    [InlineData("63", "Divide", "21", "3")]
    [InlineData("56", "Multiply", "7", "392")]
    public async Task Calculate_CorrectArguments_CorrectResultReturned(string val1, string operation, string val2, string expected)
    {
        var response = await _client.GetAsync($"{_url}/Calculator/Calculate?val1={val1}&operation={operation}&val2={val2}");
        var actual = await response.Content.ReadAsStringAsync();
        Assert.Equal(expected, actual);
    }
        
    [Theory]
    [InlineData("a", "Plus", "4", "Введите числа")]
    [InlineData("1000", "Minus", "b",  "Введите числа")]
    [InlineData("63", "papich", "3", "Недопустимая операция. Допустимые: plus, minus, multiply и divide")]
    [InlineData("63", "Divide", "0", "Деление на 0. Результат не определён")]
    public async Task Calculate_IncorrectArguments_ExceptionStringReturned(string val1, string operation, string val2, string expected)
    {
        var response = await _client.GetAsync($"{_url}/Calculator/Calculate?val1={val1}&operation={operation}&val2={val2}");
        var actual = await response.Content.ReadAsStringAsync();
        Assert.Equal(expected, actual);
    }
}