using PayFlow.Domain.DTO;
using PayFlow.Domain.Interfaces;
using PayFlow.Domain.Models;

namespace PayFlow.Domain.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly ISecurePayService _securePayService;
        private readonly IFastPayService _fastPayService;

        public PaymentService(ISecurePayService securePayService, IFastPayService fastPayService)
        {
            _securePayService = securePayService;
            _fastPayService = fastPayService;
        }

        public async Task<Payment> Create(PaymentRequest paymentRequest)
        {
            if ( paymentRequest.Amount < 100 && _fastPayService.IsAvailable())
            {
                return await _fastPayService.Create(paymentRequest);
            }
            else if(paymentRequest.Amount > 100 && !_securePayService.IsAvailable())
            {
                return await _fastPayService.Create(paymentRequest);
            }

            return await _securePayService.Create(paymentRequest);
        }
    }
}
