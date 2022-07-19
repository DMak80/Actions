using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using HomeWork9.Dto;
using HomeWork9.Services.MathCalculator;
using Microsoft.AspNetCore.Mvc;

namespace HomeWork9.Controllers
{
    public class CalculatorController : Controller
    {
        private readonly IMathCalculatorService _mathCalculatorService;

        public CalculatorController(IMathCalculatorService mathCalculatorService)
        {
            _mathCalculatorService = mathCalculatorService;
        }
        
        [HttpGet]
        [ExcludeFromCodeCoverage]
        public IActionResult Calculator()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult<CalculationMathExpressionResultDto>> CalculateMathExpression(string expression)
        {
            var result = await _mathCalculatorService.CalculateMathExpressionAsync(expression);
            return Json(result);
        }
    }
}