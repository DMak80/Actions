using System.Linq.Expressions;

namespace HomeWork9.Services.MathCalculator.MathExpressionGraph;

public interface ICalculationGraphBuilder
{
    Dictionary<Expression, MathExpression> BuildDependenciesGraphOfExpressionCalculation(
        Expression expression);
}