using Homework11.Exceptions;
using Homework11.Services.MathCalculator.MathExpressionGraph;
using Homework11.Services.MathCalculator.ParallelCalculator;
using Homework11.Services.MathCalculator.Parser;
using Homework11.Services.MathCalculator.Validator;

namespace Homework11.Services.MathCalculator;

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

    public async Task<double> CalculateMathExpressionAsync(string? expression)
    {
        var tokens = _mathExpressionParser.ParseStringExpressionToTokens(expression);

        if (!_mathExpressionValidator.IsCorrectExpression(tokens, out var errorMessage))
            throw new InvalidSyntaxException(errorMessage);
        
        var convertedExpression = _mathExpressionParser.ParseTokensToExpressionTree(tokens);
        var calculationGraph = _calculationGraphBuilder
            .BuildDependenciesGraphOfExpressionCalculation(convertedExpression);
        var result = await _mathExpressionCalculator.CalculateAsync(convertedExpression, calculationGraph);

        return result;
    }
}