using System.Linq.Expressions;

namespace Homework10.Services.MathCalculator.MathExpressionGraph;

public record MathExpression(Expression LeftExpression, Expression RightExpression);