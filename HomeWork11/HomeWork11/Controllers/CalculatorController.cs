using Homework11.Exceptions;
using HomeWork11.Models;
using HomeWork11.Services.Calculator;
using Microsoft.AspNetCore.Mvc;

namespace HomeWork11.Controllers
{
    public class CalculatorController : Controller
    {
        private readonly ICalculator _calculator;
        private readonly IExceptionHandler _exceptionHandler;

        public CalculatorController(ICalculator calculator, IExceptionHandler exceptionHandler)
        {
            _calculator = calculator;
            _exceptionHandler = exceptionHandler;
        }
        
        [HttpGet]
        public IActionResult Calculator()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CalculateMathExpression(string expression)
        {
            ResultModel model;
            try
            {
                var result = _calculator.Calculate(expression);
                model = new ResultModel($"Result: {result}");
            }
            catch (Exception e)
            {
                _exceptionHandler.HandleException(e);
                model = new ResultModel($"Error: {e.Message}");
            }
            return View("~/Views/Calculator/Calculator.cshtml", model);
        }
    }
}