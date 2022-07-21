using System.Diagnostics.CodeAnalysis;
using Homework11.Configuration;
using Homework11.Exceptions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddMathCalculator();
builder.Services.AddTransient<IExceptionHandler, ExceptionHandler>();

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

[ExcludeFromCodeCoverage]
public partial class Program { }