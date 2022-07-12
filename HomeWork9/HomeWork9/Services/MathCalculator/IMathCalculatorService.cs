using HomeWork9.Dto;

namespace HomeWork9.Services.MathCalculator;

public interface IMathCalculatorService
{
    public Task<CalculationMathExpressionResultDto> CalculateMathExpressionAsync(string expression);
}