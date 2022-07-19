using System.Linq.Expressions;
using Homework11.Services.MathCalculator.MathExpressionGraph;

namespace Homework11.Services.MathCalculator.ParallelCalculator;

public interface IMathExpressionCalculator
{
    Task<double> CalculateAsync(Expression current, IReadOnlyDictionary<Expression, MathExpression> dependencies);
}