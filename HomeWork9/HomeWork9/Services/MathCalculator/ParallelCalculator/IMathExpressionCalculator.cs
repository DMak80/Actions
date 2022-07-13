using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using HomeWork9.Services.MathCalculator.MathExpressionGraph;

namespace HomeWork9.Services.MathCalculator.ParallelCalculator;

public interface IMathExpressionCalculator
{
    Task<double> CalculateAsync(Expression current, IReadOnlyDictionary<Expression, MathExpression> dependencies);
}