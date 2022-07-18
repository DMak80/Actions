using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using Homework8.Calculator;
using Microsoft.AspNetCore.Mvc;

namespace Homework8.Controllers;

public class CalculatorController : Controller
{
    public IActionResult Calculate([FromServices] ICalculator calculator,
        string val1,
        string operation,
        string val2)
    {
        var val1IsDouble = double.TryParse(val1, NumberStyles.Number, CultureInfo.InvariantCulture,  out var v1);
        var val2IsDouble = double.TryParse(val2, NumberStyles.Number, CultureInfo.InvariantCulture,  out var v2);
        if (!val1IsDouble || !val2IsDouble)
            return View(model: "Введите числа");

        var isOperation = Enum.TryParse<Operation>(operation, true, out var op);
        if (!isOperation)
            return View(model: "Недопустимая операция. Допустимые: plus, minus, multiply и divide");
            
        var result = op switch
        {
            Operation.Plus => calculator.Plus(v1, v2),
            Operation.Minus => calculator.Minus(v1, v2),
            Operation.Multiply => calculator.Multiply(v1, v2),
            Operation.Divide => calculator.Divide(v1, v2),
        };

        return View(model: result);
    }
    
    [ExcludeFromCodeCoverage]
    public IActionResult Index()
    {
        return View();
    }
}