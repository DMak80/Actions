using System.Diagnostics.CodeAnalysis;
using Homework10.Configuration;

namespace Homework10;

[ExcludeFromCodeCoverage]
public class Program
{
    static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllersWithViews();

        builder.Services
            .AddMathCalculator()
            .AddCachedMathCalculator();

        var app = builder.Build();
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
        }
        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseRouting();
        app.UseAuthorization();
        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Calculator}/{action=Calculator}/{id?}");
        app.Run();
    }
}