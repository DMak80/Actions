using System.Linq.Expressions;
using Homework10.Services.MathCalculator.MathExpressionToken;

namespace Homework10.Services.MathCalculator.Parser;

public interface IMathExpressionParser
{
    ParseResult ParseStringExpressionToTokens(string? expression);
    Expression ParseTokensToExpressionTree(IEnumerable<Token> tokens);
}