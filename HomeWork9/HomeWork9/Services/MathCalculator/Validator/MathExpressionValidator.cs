using System.Collections.Generic;
using System.Linq;
using HomeWork9.Services.MathCalculator.MathExpressionToken;

namespace HomeWork9.Services.MathCalculator.Validator;

public class MathExpressionValidator: IMathExpressionValidator
{
    public bool IsCorrectExpression(IEnumerable<Token> expressionInTokens, out string errorMessage)
    {
        if (!expressionInTokens.Any())
        {
            errorMessage = "Empty string";
            return false;
        }
        
        var amountOpeningBrackets = 0;
        errorMessage = "";
        Token? lastToken = null;
        
        foreach (var currentToken in expressionInTokens)
        {
            switch (currentToken.Type)
            {
                case TokenType.Number:
                    break;
                case TokenType.Operation:
                    if (lastToken is null)
                        errorMessage = "An expression cannot start with an operation sign";
                    if (lastToken is { Type: TokenType.Operation })
                        errorMessage = $"There are two operations in a row {lastToken.Value.Value} and {currentToken.Value}";
                    if (lastToken is {Value: "("} && currentToken.Value != "-")
                        errorMessage = "After the opening brackets, only negation can go:" +
                                       $" {lastToken.Value.Value}{currentToken.Value}";
                    break;
                case TokenType.Bracket:
                    if (currentToken.Value == "(")
                        amountOpeningBrackets++;
                    if (currentToken.Value == ")")
                    {
                        amountOpeningBrackets--;
                        if (amountOpeningBrackets < 0)
                        {
                            errorMessage = "The number of closing and opening brackets does not match";
                        }
                    }
                    if (lastToken?.Type is TokenType.Operation && currentToken.Value == ")")
                        errorMessage = "There is only a number before the closing parenthesis" +
                                       $" {lastToken.Value.Value}{currentToken.Value}";
                    break;
            }

            if (!string.IsNullOrEmpty(errorMessage))
                return false;
            lastToken = currentToken;
        }

        if (lastToken != null && lastToken.Value.Type == TokenType.Operation)
        {
            errorMessage = "An expression cannot end with an operation sign";
            return false;
        }

        if (amountOpeningBrackets != 0)
        {
            errorMessage = "The number of closing and opening brackets does not match";
            return false;
        }

        return true;
    }
}