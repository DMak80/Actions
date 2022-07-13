using HomeWork9.Services.MathCalculator;
using HomeWork9.Services.MathCalculator.MathExpressionGraph;
using HomeWork9.Services.MathCalculator.ParallelCalculator;
using HomeWork9.Services.MathCalculator.Parser;
using HomeWork9.Services.MathCalculator.Validator;

namespace HomeWork9.Configuration;

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