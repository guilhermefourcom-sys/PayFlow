using PayFlow.Domain.DTO;
using PayFlow.Domain.Models;

namespace PayFlow.Domain.Interfaces
{
    public interface IFastPayService
    {
        Task<Payment> Create(PaymentRequest paymentRequest);
        Task<FastPay> Create(FastPayRequest fastPayRequest);
        bool IsAvailable();
    }
}
