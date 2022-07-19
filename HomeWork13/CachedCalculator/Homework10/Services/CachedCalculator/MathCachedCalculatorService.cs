using System.Collections.Concurrent;
using Homework10.Dto;
using Homework10.Services.MathCalculator;

namespace Homework10.Services.CachedCalculator;

public class MathCachedCalculatorService : IMathCalculatorService
{
	private static readonly ConcurrentDictionary<string, double> HashedExpression = new();
	private readonly IMathCalculatorService _simpleCalculator;

	public MathCachedCalculatorService(IMathCalculatorService simpleCalculator)
	{
		_simpleCalculator = simpleCalculator;
	}

	public async Task<CalculationMathExpressionResultDto> CalculateMathExpressionAsync(string? expression)
	{
		var expressionWithoutSpace = expression?.Replace(" ", "");
		
		if (TryGetSolvingExpressionResult(expressionWithoutSpace, out var solvingExpressionResult)) 
			return new CalculationMathExpressionResultDto(solvingExpressionResult);

		var result = await _simpleCalculator.CalculateMathExpressionAsync(expression);
		if (!result.IsSuccess)
			return result;

		AddSolvingExpression(expressionWithoutSpace, result.Result);
		return result;
	}

	private bool TryGetSolvingExpressionResult(
		string? expressionWithoutSpace,
		out double solvingExpressionResult)
	{
		if (expressionWithoutSpace != null && HashedExpression.ContainsKey(expressionWithoutSpace))
		{
			solvingExpressionResult = HashedExpression[expressionWithoutSpace];
			return true;
		}

		solvingExpressionResult = 0;
		return false;
	}

	private void AddSolvingExpression(string? expressionWithoutSpace, double calculationResult)
	{
		if (expressionWithoutSpace != null) HashedExpression.TryAdd(expressionWithoutSpace, calculationResult);
	}
}