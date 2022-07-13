using Homework11.Services.MathCalculator;
using Homework11.Services.MathCalculator.MathExpressionGraph;
using Homework11.Services.MathCalculator.ParallelCalculator;
using Homework11.Services.MathCalculator.Parser;
using Homework11.Services.MathCalculator.Validator;

namespace Homework11.Configuration;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddMathCalculator(this IServiceCollection services)
    {
        return services.AddTransient<IMathCalculatorService, MathCalculatorService>()
            .AddTransient<ICalculationGraphBuilder, CalculationGraphBuilder>()
            .AddSingleton<IMathExpressionCalculator, MathExpressionCalculator>()
            .AddSingleton<IMathExpressionValidator, MathExpressionValidator>()
            .AddSingleton<IMathExpressionParser, MathExpressionParser>();
    }
}