using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using PayFlow.Domain.DTO;
using PayFlow.Domain.Interfaces;

namespace PayFlow.Api.Controllers
{
    [ApiController, Route("api/[controller]"), EnableCors("General")]
    public class PaymentsController : ControllerBase
    {
        private IPaymentService _paymentService;

        public PaymentsController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpPost]
        public async Task<IActionResult> PaymentsAsync([FromBody] PaymentRequest paymentRequest)
        {
           var payment = await _paymentService.Create(paymentRequest);
            return Created("", payment);
        }
    }
}
