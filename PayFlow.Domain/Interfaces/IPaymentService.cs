using PayFlow.Domain.DTO;
using PayFlow.Domain.Models;

namespace PayFlow.Domain.Interfaces
{
    public interface IPaymentService
    {
        Task<Payment> Create(PaymentRequest paymentRequest);
    }
}
