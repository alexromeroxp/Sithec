using Microsoft.AspNetCore.Mvc;
using Sithec.Interfaces;
using Sithec.Models;

namespace Sithec.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MathController : ControllerBase
    {

        private readonly IMathService _mathService;

        public MathController(IMathService mathService)
        {
            _mathService = mathService;
        }

        [HttpGet]
        public ActionResult<MathResult> CalculateResult()
        {
            if (Request.Headers.TryGetValue("Argument1", out var Operator1Header) &&
                Request.Headers.TryGetValue("Argument2", out var Operator2Header) &&
                Request.Headers.TryGetValue("Argument3", out var Operator3Header))
            {
                MathResult result =  _mathService.GetResultOfOperations(Operator1Header, Operator2Header, Operator3Header);

                if (double.IsNaN(result.Sum) || double.IsNaN(result.Difference) || double.IsNaN(result.Product) || double.IsNaN(result.Quotient)) 
                {
                    return BadRequest("Some Operation is invalid");

                }
                return result;


            }
            return BadRequest("Invalid Operators");
        }

        [HttpPost]
        public ActionResult<MathResult> CalculateResultPost([FromBody] Operators Operators)
        {
            if (Operators != null)
            {
                MathResult result = _mathService.GetResultOfOperations(Operators.Operator1, Operators.Operator2, Operators.Operator3);

                if (double.IsNaN(result.Sum) || double.IsNaN(result.Difference) || double.IsNaN(result.Product) || double.IsNaN(result.Quotient))
                {
                    return BadRequest("Some Operation is invalid");

                }
                return result;
            }

            return BadRequest("Invalid Operators");
        }
    }

}