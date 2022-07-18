using Homework11.ErrorMessages;
using Homework11.Services.MathCalculator.MathExpressionToken;

namespace Homework11.Services.MathCalculator.Validator;

public class MathExpressionValidator: IMathExpressionValidator
{
   public bool IsCorrectExpression(IEnumerable<Token> expressionInTokens, out string errorMessage)
    {
        if (!expressionInTokens.Any())
        {
            errorMessage = MathErrorMessager.EmptyString;
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
                        errorMessage = MathErrorMessager.StartingWithOperation;
                    if (lastToken is { Type: TokenType.Operation })
                        errorMessage = MathErrorMessager.TwoOperationInRowMessage(lastToken.Value.Value, currentToken.Value);
                    if (lastToken is { Value: "(" } && currentToken.Value != "-")
                        errorMessage = MathErrorMessager.InvalidOperatorAfterParenthesisMessage(currentToken.Value);
                    break;
                case TokenType.Bracket:
                    if (currentToken.Value == "(")
                        amountOpeningBrackets++;
                    if (currentToken.Value == ")")
                    {
                        amountOpeningBrackets--;
                        if (amountOpeningBrackets < 0)
                        {
                            errorMessage = MathErrorMessager.IncorrectBracketsNumber;
                        }
                    }

                    if (lastToken?.Type is TokenType.Operation && currentToken.Value == ")")
                        errorMessage = MathErrorMessager.OperationBeforeParenthesisMessage(lastToken.Value.Value);
                    break;
            }

            if (!string.IsNullOrEmpty(errorMessage))
                return false;
            lastToken = currentToken;
        }

        if (lastToken?.Type == TokenType.Operation)
        {
            errorMessage = MathErrorMessager.EndingWithOperation;
            return false;
        }

        if (amountOpeningBrackets != 0)
        {
            errorMessage = MathErrorMessager.IncorrectBracketsNumber;
            return false;
        }

        return true;
    }
}