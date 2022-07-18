using System.Diagnostics.CodeAnalysis;
using Homework10.Dto;
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
    public ActionResult<CalculationMathExpressionResultDto> CalculateMathExpression(string expression)
    {
        throw new NotImplementedException();
    }
}