using Homework11.Services.MathCalculator.MathExpressionToken;

namespace Homework11.Services.MathCalculator.Validator;

public interface IMathExpressionValidator
{
    bool IsCorrectExpression(IEnumerable<Token> expressionInTokens, out string errorMessage);
}