using System.Collections.Generic;
using HomeWork9.Services.MathCalculator.MathExpressionToken;

namespace HomeWork9.Services.MathCalculator.Parser;

public class ParseResult
{
    public ParseResult(List<Token>? tokens)
    {
        IsSuccess = true;
        Tokens = tokens; 
    }
    
    public ParseResult(string? errorMessage)
    {
        IsSuccess = false;
        ErrorMessage = errorMessage;
    }
    
    public bool IsSuccess { get; }
    public List<Token>? Tokens { get; }
    public string? ErrorMessage { get; }
}