using Homework10.Dto;

namespace Homework10.Services.MathCalculator;

public interface IMathCalculatorService
{
    public Task<CalculationMathExpressionResultDto> CalculateMathExpressionAsync(string? expression);
}