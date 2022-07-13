using System.Globalization;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Homework10;
using Homework10.Dto;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace Hw10Tests;

public class IntegrationCalculatorControllerTests : IClassFixture<WebApplicationFactory<Program>>
{
	private readonly HttpClient _client;

	public IntegrationCalculatorControllerTests(WebApplicationFactory<Program> fixture)
	{
		_client = fixture.CreateClient();
	}
	
	[Theory]
	[InlineData("2 + 3", "5")]
	[InlineData("(10 - 3) * 2", "14")]
	[InlineData("3 - 4 / 2", "1")]
	[InlineData("8 * (2 + 2) - 3 * 4", "20")]
	[InlineData("10 - 3 * (-4)", "22")]
	public async Task Calculate_CalculateExpression_Success(string expression, string result)
	{
		var response = await CalculateAsync(expression);
		Assert.True(response!.IsSuccess);
		Assert.Equal(result, response.Result.ToString(CultureInfo.InvariantCulture));
	}
	
	[Theory]
	[InlineData(null, "Empty string")]
	[InlineData("", "Empty string")]
	[InlineData("10 + i", "Unknown character i")]
	[InlineData("10 : 2", "Unknown character :")]
	[InlineData("3 - 4 / 2.2.3", "There is no such number 2.2.3")]
	[InlineData("2 - 2.23.1 - 23", "There is no such number 2.23.1")]
	[InlineData("8 - / 2", "There are two operations in a row - and /")]
	[InlineData("8 + (34 - + 2)", "There are two operations in a row - and +")]
	[InlineData("4 - 10 * (/10 + 2)", "After the opening brackets, only negation can go: (/")]
	[InlineData("10 - 2 * (10 - 1 /)", "There is only a number before the closing parenthesis /)")]
	[InlineData("* 10 + 2", "An expression cannot start with an operation sign")]
	[InlineData("10 + 2 -", "An expression cannot end with an operation sign")]
	[InlineData("((10 + 2)", "The number of closing and opening brackets does not match")]
	[InlineData("(10 - 2))", "The number of closing and opening brackets does not match")]
	[InlineData("10 / 0", "Division by zero")]
	[InlineData("10 / (1 - 1)", "Division by zero")]
	public async Task Calculate_CalculateExpression_Error(string expression, string result)
	{
		var response = await CalculateAsync(expression);
		Assert.False(response!.IsSuccess);
		Assert.Equal(result, response.ErrorMessage);
	}

	private async Task<CalculationMathExpressionResultDto?> CalculateAsync(string expression)
	{
		var response = await _client.PostCalculateExpressionAsync(expression);
		return await response.Content.ReadFromJsonAsync<CalculationMathExpressionResultDto>();
	}
}