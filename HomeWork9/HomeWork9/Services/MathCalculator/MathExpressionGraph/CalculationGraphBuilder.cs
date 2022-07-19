using System.Linq.Expressions;

namespace HomeWork9.Services.MathCalculator.MathExpressionGraph;

public class CalculationGraphBuilder : ExpressionVisitor, ICalculationGraphBuilder
{
    private readonly Dictionary<Expression, MathExpression> _dependencies = new();

    public Dictionary<Expression, MathExpression> 
        BuildDependenciesGraphOfExpressionCalculation(Expression expression)
    {
        Visit(expression);
        return _dependencies;
    }
        
    protected override Expression VisitBinary(BinaryExpression node)
    {
        _dependencies.Add(node, new MathExpression(node.Left, node.Right));
        Visit(node.Left);
        Visit(node.Right);
        return node;
    }
}