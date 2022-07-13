using HomeWork9.Services.MathCalculator.MathExpressionToken;

namespace HomeWork9.Services.MathCalculator.Validator;

public interface IMathExpressionValidator
{
    bool IsCorrectExpression(IEnumerable<Token> expressionInTokens, out string errorMessage);
}