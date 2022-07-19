using Homework10.DbModels;
using Homework10.Dto;
using Homework10.Services.MathCalculator;

namespace Homework10.Services.CachedCalculator;

public class MathCachedCalculatorService : IMathCalculatorService
{
	private readonly ApplicationContext _dbContext;
	private readonly IMathCalculatorService _simpleCalculator;

	public MathCachedCalculatorService(ApplicationContext dbContext, IMathCalculatorService simpleCalculator)
	{
		_dbContext = dbContext;
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

		await AddSolvingExpression(expressionWithoutSpace, result.Result);
		return result;
	}

	private bool TryGetSolvingExpressionResult(
		string? expressionWithoutSpace,
		out double solvingExpressionResult)
	{
		var possibleResult = _dbContext.SolvingExpressions
			.FirstOrDefault(exp => exp.Expression == expressionWithoutSpace);
		if (possibleResult is not null)
		{
			solvingExpressionResult = possibleResult.Result;
			return true;
		}

		solvingExpressionResult = 0;
		return false;
	}

	private async Task AddSolvingExpression(string? expressionWithoutSpace, double calculationResult)
	{
		var solvingExpression = new SolvingExpression
		{
			Expression = expressionWithoutSpace!,
			Result = calculationResult
		};
		_dbContext.Add(solvingExpression);
		await _dbContext.SaveChangesAsync();
	}
}