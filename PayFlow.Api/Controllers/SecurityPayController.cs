using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using PayFlow.Domain.DTO;
using PayFlow.Domain.Interfaces;

namespace PayFlow.Api.Controllers
{
    [ApiController, Route("api/[controller]"), EnableCors("General")]
    public class SecurityPayController : ControllerBase
    {
        private ISecurePayService _securePayService;

        public SecurityPayController(ISecurePayService securePayService)
        {
            _securePayService = securePayService;
        }

        [HttpPost]
        public async Task<IActionResult> PaymentsAsync([FromBody] SecurePayRequest securePayRequest)
        {
            var securePay = await _securePayService.Create(securePayRequest);
            var securePayResponse = new SecurePayResponse
            {
                TransactionId = securePay.Id,
                Result = SecurePayResult.Success.ToString()
            };
            return Created("", securePayResponse);
        }
    }
}
