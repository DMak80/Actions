namespace HomeWork9.Services.MathCalculator.MathExpressionToken;

public readonly struct Token
{
    public readonly TokenType Type;
    public readonly string Value;
    
    public bool IsOperation => Type == TokenType.Operation;

    public Token(TokenType type, string value)
    {
        Type = type;
        Value = value;
    }
}