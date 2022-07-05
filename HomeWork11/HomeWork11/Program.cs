using HomeWork11.DbModels;
using Homework11.Exceptions;
using HomeWork11.Exceptions;
using HomeWork11.Services.Calculator;
using HomeWork11.Services.HashedCalculator;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ApplicationContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<ICalculator>(s =>
    new HashedCalculator(s.GetService<ApplicationContext>()!, new Calculator()));
builder.Services.AddScoped<IExceptionHandler, ExceptionHandler>();

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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

public partial class Program
{
    
}