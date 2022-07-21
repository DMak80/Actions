using System.Linq.Expressions;
using Homework10.Services.MathCalculator.MathExpressionGraph;

namespace Homework10.Services.MathCalculator.ParallelCalculator;

public interface IMathExpressionCalculator
{
    Task<double> CalculateAsync(Expression current, IReadOnlyDictionary<Expression, MathExpression> dependencies);
}