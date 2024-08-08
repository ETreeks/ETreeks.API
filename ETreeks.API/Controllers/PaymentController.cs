using ETreeks.Core.Data;
using ETreeks.Core.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ETreeks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _paymentService;

        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpPost("IsValidPayment")]
        public async Task<bool> IsValidPayment([FromBody] Paymant request)
        {
            return await _paymentService.IsValidPayment(request.Firstname, request.Lastname, (int)request.Cardnumber, (int)request.Cvv, (DateTime)request.Expirydate);
        }

        [HttpGet("GetUserBalance")]
        public async Task<decimal?> GetUserBalance([FromQuery] decimal cardNumber, [FromQuery] decimal cvv)
        {
            return await _paymentService.GetUserBalance(cardNumber, cvv);
        }

        [HttpPost("ProcessPayment/{amount}")]
        public async Task<IActionResult> ProcessPayment([FromBody] Paymant request, [FromRoute] int amount)
        {
            // Call CheckPayment to validate payment details
            var paymentDetails = await _paymentService.CheckPayment(request.Firstname, request.Lastname,
                 (int)request.Cardnumber, (int)request.Cvv, (DateTime)request.Expirydate);

            // If payment details are not valid, return an appropriate response
            if (paymentDetails == null)
            {
                return BadRequest("Invalid payment details.");
            }
            // Check user balance
            var balance = await _paymentService.GetUserBalance((decimal)request.Cardnumber, (decimal)request.Cvv);

            // If balance is insufficient or zero, return an appropriate response
            if (balance == null || balance < amount)
            {
                return BadRequest("Insufficient balance.");
            }

            await _paymentService.ProcessPayment(request.Firstname, request.Lastname, (int)request.Cardnumber, (int)request.Cvv, (DateTime)request.Expirydate, amount);
            return Ok();
        }

        [HttpPost("CheckPayment")]
        public async Task<Paymant> CheckPayment([FromBody] Paymant request)
        {
            return await _paymentService.CheckPayment(request.Firstname, request.Lastname, (int)request.Cardnumber, (int)request.Cvv, (DateTime)request.Expirydate);
        }
    }
}
