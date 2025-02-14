using System.Globalization;
using Microsoft.AspNetCore.Mvc;

namespace RestDotNetUdemy.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculatorController : ControllerBase
    {
        private readonly ILogger<CalculatorController> _logger;

        public CalculatorController(ILogger<CalculatorController> logger)
        {
            _logger = logger;
        }

        [HttpGet("sum/{firstNum}/{secondNum}")]
        public IActionResult Sum(string firstNum, string secondNum)
        {
            if (IsNumber(firstNum) && IsNumber(secondNum))
            {
                var sum = ConvertToDecimal(firstNum) + ConvertToDecimal(secondNum);
                return Ok(sum);
            }
            return BadRequest("Invalid output!");
        }

        [HttpGet("subtract/{firstNum}/{secondNum}")]
        public IActionResult Subtraction(string firstNum, string secondNum)
        {
            if (IsNumber(firstNum) && IsNumber(secondNum))
            {
                var subtract = ConvertToDecimal(firstNum) - ConvertToDecimal(secondNum);
                return Ok(subtract);
            }
            return BadRequest("Invalid output!");
        }

        private static decimal ConvertToDecimal(string strNumber)
        {
            var result = decimal.TryParse(strNumber, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal number) ? number : 0;
            return number;
        }

        private static bool IsNumber(string strNumber)
        {
            bool isNum = double.TryParse(strNumber, NumberStyles.Any, CultureInfo.InvariantCulture, out double number);
            return isNum;
        }
    }
}
