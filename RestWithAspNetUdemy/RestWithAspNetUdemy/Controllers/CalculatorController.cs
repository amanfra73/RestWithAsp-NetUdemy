using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace RestWithAspNetUdemy.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CalculatorController : ControllerBase
    {

        // GET api/values/S/S
        [HttpGet("{firstnumber}/{secondnumber}")]

        
            public IActionResult Sum(string firstnumber, string secondnumber)
            {

            if (IsNumeric(firstnumber) && IsNumeric(secondnumber) )
            {
                var sum = ConvertToDecimal(firstnumber) + ConvertToDecimal(secondnumber);
                return Ok(sum.ToString());
            }
            return BadRequest("Invalid Input") ; 
            }

        private decimal ConvertToDecimal(string firstnumber)
        {
            decimal decvalue;

            if (decimal.TryParse(firstnumber, out decvalue))
            {
                return decvalue;
            }


            return 0;
            
        }

        private bool IsNumeric(string strnumber)
        {
            double number;
            bool isNumbe = double.TryParse(strnumber, System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out number);
           return isNumbe;
        }
    }
}



