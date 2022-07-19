using System.Linq.Expressions;

namespace Homework11.Services.MathCalculator.MathExpressionGraph;

public record MathExpression(Expression LeftExpression, Expression RightExpression);