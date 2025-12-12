using PayFlow.Domain.DTO;
using PayFlow.Domain.Interfaces;
using PayFlow.Domain.Models;

namespace PayFlow.Domain.Services
{
    public class SecurePayService : ISecurePayService
    {
        private readonly IRepository repository;

        public SecurePayService(IRepository repository)
        {
            this.repository = repository;
        }

        public async Task<Payment> Create(PaymentRequest paymentRequest)
        {
            var payment = await repository.AddAsync(new Payment
            {
                GrossAmount = paymentRequest.Amount,
                Provider = Models.PaymentProvider.SecurePay,
                Status = Models.PaymentStatus.Approved,
                Fee = CalculateFee(paymentRequest.Amount),
                NetAmount = paymentRequest.Amount - CalculateFee(paymentRequest.Amount)
            });

            return payment;
        }

        public async Task<SecurePay> Create(SecurePayRequest securePayRequest)
        {
            var securePay = await repository.AddAsync(new SecurePay
            {
                Id = $"SP-{new Random().Next(10000, 20000)}",
                AmountCents = securePayRequest.AmountCents,
                CurrencyCode = securePayRequest.CurrencyCode,
                ClientReference = securePayRequest.ClientReference
            });

            return securePay;
        }

        private decimal CalculateFee(decimal amount)
        {
            return Math.Round(((amount / 100) * 2.99m) + 0.40m, 2);
        }

        public bool IsAvailable()
        {
            var random = new Random().Next(0, 6);
            return random > 3;
        }
    }
}
