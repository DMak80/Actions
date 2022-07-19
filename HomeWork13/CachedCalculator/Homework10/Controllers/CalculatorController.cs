using System.Diagnostics.CodeAnalysis;
using Homework10.Dto;
using Homework10.Services.MathCalculator;
using Microsoft.AspNetCore.Mvc;

namespace Homework10.Controllers;

public class CalculatorController : Controller
{
    [HttpGet]
    [ExcludeFromCodeCoverage]
    public IActionResult Calculator()
    {
        return View();
    }

    [HttpPost]
    public async Task<ActionResult<CalculationMathExpressionResultDto>> CalculateMathExpression(string expression)
    {
        throw new NotImplementedException();
    }
}