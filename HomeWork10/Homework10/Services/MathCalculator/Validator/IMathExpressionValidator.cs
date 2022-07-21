using Homework10.Services.MathCalculator.MathExpressionToken;

namespace Homework10.Services.MathCalculator.Validator;

public interface IMathExpressionValidator
{
    bool IsCorrectExpression(IEnumerable<Token> expressionInTokens, out string errorMessage);
}