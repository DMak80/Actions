using System.Linq.Expressions;
using Homework11.Services.MathCalculator.MathExpressionToken;

namespace Homework11.Services.MathCalculator.Parser;

public interface IMathExpressionParser
{
    List<Token> ParseStringExpressionToTokens(string? expression);
    Expression ParseTokensToExpressionTree(IEnumerable<Token> tokens);
}