using System.Linq.Expressions;

namespace Homework11.Services.MathCalculator.MathExpressionGraph;

public class CalculationGraphBuilder : ICalculationGraphBuilder
{
    private readonly Dictionary<Expression, MathExpression> _dependencies = new();

    public Dictionary<Expression, MathExpression> 
        BuildDependenciesGraphOfExpressionCalculation(Expression expression)
    {
        Visit((dynamic)expression);
        return _dependencies;
    }
        
    private void Visit(BinaryExpression node)
    {
        _dependencies.Add(node, new MathExpression(node.Left, node.Right));
        Visit((dynamic)node.Left);
        Visit((dynamic)node.Right);
    }
    
    private void Visit(ConstantExpression node)
    {
    }
}