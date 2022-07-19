using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using Homework8.Calculator;
using Microsoft.AspNetCore.Mvc;

namespace Homework8.Controllers;

public class CalculatorController : Controller
{
    public string Calculate([FromServices] ICalculator calculator,
        string val1,
        string operation,
        string val2)
    {
        var val1IsDouble = double.TryParse(val1, NumberStyles.Number, CultureInfo.InvariantCulture,  out var v1);
        var val2IsDouble = double.TryParse(val2, NumberStyles.Number, CultureInfo.InvariantCulture,  out var v2);
        if (!val1IsDouble || !val2IsDouble)
            return Messages.InvalidNumberMessage; 

        var isOperation = Enum.TryParse<Operation>(operation, true, out var op);
        if (!isOperation || op is Operation.Invalid)
            return Messages.InvalidOperationMessage;

        string result = "";
        switch (op)
        {
            case Operation.Plus:
                result = calculator.Plus(v1, v2);
                break;
            case Operation.Minus:
                result = calculator.Minus(v1, v2);
                break;
            case Operation.Multiply:
                result =  calculator.Multiply(v1, v2);
                break;
            case Operation.Divide:
                result =  calculator.Divide(v1, v2);
                break;
        }

        return result;
    }
    
    [ExcludeFromCodeCoverage]
    public IActionResult Index()
    {
        return Content(
            "Заполните val1, operation(plus, minus, multiply, divide) и val2 здесь '/calculator/calculate?val1= &operation= &val2= '\n" +
            "и добавьте её в адресную строку.");
    }
}