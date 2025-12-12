using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using PayFlow.Domain.DTO;
using PayFlow.Domain.Interfaces;

namespace PayFlow.Api.Controllers
{
    [ApiController, Route("api/[controller]"), EnableCors("General")]
    public class FastPayController : ControllerBase
    {
        private IFastPayService _fastPayService;

        public FastPayController(IFastPayService fastPayService)
        {
            _fastPayService = fastPayService;
        }

        [HttpPost]
        public async Task<IActionResult> PaymentsAsync([FromBody] FastPayRequest fastPayRequest)
        {
            var fastPay = await _fastPayService.Create(fastPayRequest);
            var fastPayResponse = new FastPayResponse
            {
                Id = fastPay.Id,
                Status = fastPay.Status.ToString(),
                StatusDetail = fastPay.StatusDetail
            };
            return Created("", fastPayResponse);
        }
    }
}
