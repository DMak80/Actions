using BenchmarkDotNet.Attributes;
using Homework8.Calculator;
using Hw6;

namespace Homework12;

[MaxColumn]
[MinColumn]
public class WebApplicationWorkingTimeTests
{
	private HttpClient _cSharpClient = null!;
	private HttpClient _fSharpClient = null!;
		
	[GlobalSetup]
	public void SetUp()
	{
		_cSharpClient =  new TestApplicationFactoryCSharp().CreateClient();
		_fSharpClient =  new TestApplicationFactoryFSharp().CreateClient();
	}
		
	
		
	[Benchmark]
	public async Task PlusOperationTimeTestFSharp()
	{
		await SendRequestFSharp("1", CalculatorOperation.Plus, "2");
	}
		
	[Benchmark]
	public async Task SubtractionOperationTimeTestFSharp()
	{
		await SendRequestFSharp("3", CalculatorOperation.Minus, "2");
	}

	[Benchmark]
	public async Task MultiplicationOperationTimeTestFSharp()
	{
		await SendRequestFSharp("10", CalculatorOperation.Multiply, "3");
	}

	[Benchmark]
	public async Task DivisionOperationTimeTestFSharp()
	{
		await SendRequestFSharp("20", CalculatorOperation.Divide, "10");
	}

	private async Task SendRequestCSharp(string v1, Operation operation, string v2)
	{
		await _cSharpClient.GetAsync($"/Calculator/Calculate?val1={v1}&operation={operation}&val2={v2}");
	}
		
	private async Task SendRequestFSharp(string v1, CalculatorOperation operation, string v2)
	{
		await _fSharpClient.GetAsync($"/calculate?value1={v1}&operation={operation}&value2={v2}");
	}
}