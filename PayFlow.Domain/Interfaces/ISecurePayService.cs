using PayFlow.Domain.DTO;
using PayFlow.Domain.Models;

namespace PayFlow.Domain.Interfaces
{
    public interface ISecurePayService
    {
        Task<Payment> Create(PaymentRequest paymentRequest);
        Task<SecurePay> Create(SecurePayRequest securePayRequest);
        bool IsAvailable();
    }
}
