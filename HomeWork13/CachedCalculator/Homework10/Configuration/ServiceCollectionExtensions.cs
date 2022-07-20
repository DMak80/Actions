using Homework10.Services.CachedCalculator;
using Homework10.Services.MathCalculator;
using Homework10.Services.MathCalculator.MathExpressionGraph;
using Homework10.Services.MathCalculator.ParallelCalculator;
using Homework10.Services.MathCalculator.Parser;
using Homework10.Services.MathCalculator.Validator;

namespace Homework10.Configuration;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddMathCalculator(this IServiceCollection services)
    {
        return services.AddTransient<MathCalculatorService>()
            .AddTransient<ICalculationGraphBuilder, CalculationGraphBuilder>()
            .AddSingleton<IMathExpressionCalculator, MathExpressionCalculator>()
            .AddSingleton<IMathExpressionValidator, MathExpressionValidator>()
            .AddSingleton<IMathExpressionParser, MathExpressionParser>();
    }
    
    public static IServiceCollection AddCachedMathCalculator(this IServiceCollection services)
    {
        return services.AddScoped<IMathCalculatorService>(s =>
            new MathCachedCalculatorService(
                s.GetRequiredService<MathCalculatorService>()));
    }
}