using System.Collections.Generic;
using System.Linq.Expressions;
using HomeWork9.Services.MathCalculator.MathExpressionToken;

namespace HomeWork9.Services.MathCalculator.Parser;

public interface IMathExpressionParser
{
    ParseResult ParseStringExpressionToTokens(string? expression);
    Expression ParseTokensToExpressionTree(IEnumerable<Token> tokens);
}