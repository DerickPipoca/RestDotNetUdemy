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
        public IActionResult Subtract(string firstNum, string secondNum)
        {
            if (IsNumber(firstNum) && IsNumber(secondNum))
            {
                var subtract = ConvertToDecimal(firstNum) - ConvertToDecimal(secondNum);
                return Ok(subtract);
            }
            return BadRequest("Invalid output!");
        }

        [HttpGet("multiplication/{firstNum}/{secondNum}")]
        public IActionResult Multiplication(string firstNum, string secondNum)
        {
            if (IsNumber(firstNum) && IsNumber(secondNum))
            {
                var multiplication = ConvertToDecimal(firstNum) * ConvertToDecimal(secondNum);
                return Ok(multiplication);
            }
            return BadRequest("Invalid output!");
        }

        [HttpGet("division/{firstNum}/{secondNum}")]
        public IActionResult Division(string firstNum, string secondNum)
        {
            if (IsNumber(firstNum) && IsNumber(secondNum))
            {
                try
                {
                    var division = ConvertToDecimal(firstNum) / ConvertToDecimal(secondNum);
                    return Ok(division);
                }
                catch (DivideByZeroException ex)
                {
                    return BadRequest($"{ex.Message} - Can't divide by zero.");
                }
            }
            return BadRequest("Invalid output!");
        }

        [HttpGet("average/{firstNum}/{secondNum}")]
        public IActionResult Average(string firstNum, string secondNum)
        {
            if (IsNumber(firstNum) && IsNumber(secondNum))
            {
                var average = (ConvertToDecimal(firstNum) + ConvertToDecimal(secondNum)) / (decimal)2;
                return Ok(average);
            }
            return BadRequest("Invalid output!");
        }

        [HttpGet("squareroot/{num}")]
        public IActionResult SquareRoot(string num)
        {
            if (IsNumber(num))
            {
                var squareRoot = Math.Sqrt((double)ConvertToDecimal(num));
                return Ok(squareRoot);
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
