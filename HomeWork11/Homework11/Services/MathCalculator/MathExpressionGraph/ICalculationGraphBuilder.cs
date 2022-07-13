using System.Linq.Expressions;

namespace Homework11.Services.MathCalculator.MathExpressionGraph;

public interface ICalculationGraphBuilder
{
    Dictionary<Expression, MathExpression> BuildDependenciesGraphOfExpressionCalculation(
        Expression expression);
}