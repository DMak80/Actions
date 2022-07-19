using System.Linq.Expressions;

namespace HomeWork9.Services.MathCalculator.MathExpressionGraph;

public record MathExpression(Expression LeftExpression, Expression RightExpression);