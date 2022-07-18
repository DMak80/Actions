using System.Diagnostics.CodeAnalysis;
using HomeWork9.Dto;
using Microsoft.AspNetCore.Mvc;

namespace HomeWork9.Controllers;

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