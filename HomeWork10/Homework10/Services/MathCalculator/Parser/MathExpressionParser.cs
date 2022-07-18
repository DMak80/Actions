using System.Globalization;
using System.Linq.Expressions;
using Homework10.Services.MathCalculator.MathExpressionToken;

namespace Homework10.Services.MathCalculator.Parser;

public class MathExpressionParser: IMathExpressionParser
{
    private readonly HashSet<char> _brackets = new() {'(', ')'};
    private readonly HashSet<char>  _operations = new() {'+', '-', '/', '*'};
    
    private readonly Dictionary<string, int> _priorities = new()
    {
        {"+", 2},
        {"-", 2},
        {"*", 4},
        {"/", 4},
        {"(", 0}
    };

    private readonly Dictionary<string, ExpressionType> _expressionTypes = new()
    {
        {"+", ExpressionType.Add},
        {"-", ExpressionType.Subtract},
        {"*", ExpressionType.Multiply},
        {"/", ExpressionType.Divide}
    };

    public ParseResult ParseStringExpressionToTokens(string? expression)
    {
        if (string.IsNullOrEmpty(expression))
            return new ParseResult(new List<Token>());
        
        var tokens = new List<Token>();
        var number = "";
        var errorMessageForNum = "There is no such number ";
        
        foreach (var symbol in expression.Replace(" ", ""))
        {
            if (_brackets.Contains(symbol))
            {
                TryAddToken(ref number, tokens, symbol, TokenType.Bracket);
            }
            else if (_operations.Contains(symbol))
            {
                if (!TryAddToken(ref number, tokens, symbol, TokenType.Operation))
                    return new ParseResult($"{errorMessageForNum}{number}");
            }
            else if (char.IsDigit(symbol) || symbol == '.')
                number += symbol;
            else
                return new ParseResult($"Unknown character {symbol}");
        }

        if (!string.IsNullOrEmpty(number))
        {
            if (!double.TryParse(number, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out _))
                return new ParseResult(errorMessageForNum + number);
            
            tokens.Add(new Token(TokenType.Number, number));
        }
        
        return new ParseResult(tokens);
    }

    public Expression ParseTokensToExpressionTree(IEnumerable<Token> tokens)
    {
        var outputStack = new Stack<Expression>();
        var operatorStack = new Stack<Token>();
        var isNegativeNumber = false;
        Token? lastToken = null;
        
        foreach (var currentToken in tokens)
        {
            switch (currentToken.Type)
            {
                case TokenType.Number:
                    outputStack.Push(Expression.Constant(
                        (isNegativeNumber ? -1 : 1) * double.Parse(currentToken.Value, 
                            NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture), typeof(double)));
                    isNegativeNumber = false;
                    break;
                case TokenType.Operation:
                    if (lastToken is not null && lastToken.Value.Value == "(" && currentToken.Value == "-")
                        isNegativeNumber = true;
                    else AddOperations(currentToken, outputStack, operatorStack);
                    break;
                case TokenType.Bracket:
                    if (currentToken.Value == "(")
                        operatorStack.Push(currentToken);
                    else AddOperationsBeforeOpeningParenthesis(outputStack, operatorStack);
                    break;
            }

            lastToken = currentToken;
        }

        AddLastOperations(outputStack, operatorStack);

        return outputStack.Pop();
    }

    private bool TryAddToken(ref string num, ICollection<Token> tokens, char tokenValue, TokenType tokenType)
    {
        if (!string.IsNullOrEmpty(num))
        {
            if (!double.TryParse(num, NumberStyles.AllowDecimalPoint,  CultureInfo.InvariantCulture, out _))
                return false;
            tokens.Add(new Token(TokenType.Number, num));
            num = "";
        }

        tokens.Add(new Token(tokenType, tokenValue.ToString()));
        return true;
    }
    
    private void AddOperations(Token operation, Stack<Expression> outputStack, Stack<Token> operatorStack)
    {
        while (operatorStack.Count > 0 && _priorities[operatorStack.Peek().Value] >= _priorities[operation.Value])
            MakeBinaryExpression(outputStack, operatorStack.Pop());

        operatorStack.Push(operation);
    }

    private void AddOperationsBeforeOpeningParenthesis(Stack<Expression> outputStack, Stack<Token> operatorStack)
    {
        var operation = operatorStack.Pop();
        while (operatorStack.Count > 0 && operation.Value != "(")
        {
            MakeBinaryExpression(outputStack, operation);
            operation = operatorStack.Pop();
        }
    }

    private void AddLastOperations(Stack<Expression> outputStack, Stack<Token> operatorStack)
    {
        while (operatorStack.Count > 0)
            MakeBinaryExpression(outputStack, operatorStack.Pop());
    }
        
        
    private void MakeBinaryExpression(Stack<Expression> outputStack, Token operation)
    {
        var rightNode = outputStack.Pop();
        outputStack.Push(Expression.MakeBinary(_expressionTypes[operation.Value], outputStack.Pop(),
            rightNode));
    }
}