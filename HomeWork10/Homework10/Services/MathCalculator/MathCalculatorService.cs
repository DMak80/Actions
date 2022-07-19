using Homework10.Dto;
using Homework10.ErrorMessages;
using Homework10.Services.MathCalculator.MathExpressionGraph;
using Homework10.Services.MathCalculator.ParallelCalculator;
using Homework10.Services.MathCalculator.Parser;
using Homework10.Services.MathCalculator.Validator;

namespace Homework10.Services.MathCalculator;

public class MathCalculatorService : IMathCalculatorService
{
    private readonly IMathExpressionValidator _mathExpressionValidator;
    private readonly IMathExpressionParser _mathExpressionParser;
    private readonly ICalculationGraphBuilder _calculationGraphBuilder;
    private readonly IMathExpressionCalculator _mathExpressionCalculator;

    public MathCalculatorService(
        IMathExpressionValidator mathExpressionValidator, 
        IMathExpressionParser mathExpressionParser,
        ICalculationGraphBuilder calculationGraphBuilder,
        IMathExpressionCalculator mathExpressionCalculator)
    {
        _mathExpressionValidator = mathExpressionValidator;
        _mathExpressionParser = mathExpressionParser;
        _calculationGraphBuilder = calculationGraphBuilder;
        _mathExpressionCalculator = mathExpressionCalculator;
    }

    public async Task<CalculationMathExpressionResultDto> CalculateMathExpressionAsync(string? expression)
    {
        var parseResult = _mathExpressionParser.ParseStringExpressionToTokens(expression);
        if (!parseResult.IsSuccess)
            return new CalculationMathExpressionResultDto(parseResult.ErrorMessage!);
        
        if (!_mathExpressionValidator.IsCorrectExpression(parseResult.Tokens!, out var errorMessage))
            return new CalculationMathExpressionResultDto(errorMessage);
        
        var convertedExpression = _mathExpressionParser.ParseTokensToExpressionTree(parseResult.Tokens!);
        var calculationGraph = _calculationGraphBuilder
            .BuildDependenciesGraphOfExpressionCalculation(convertedExpression);
        var result = await _mathExpressionCalculator.CalculateAsync(convertedExpression, calculationGraph);

        if (result is double.NaN)
            return new CalculationMathExpressionResultDto(MathErrorMessager.DivisionByZero);

        return new CalculationMathExpressionResultDto(result);
    }
}