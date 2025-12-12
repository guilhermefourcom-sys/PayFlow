using PayFlow.Domain.DTO;
using PayFlow.Domain.Interfaces;
using PayFlow.Domain.Models;

namespace PayFlow.Domain.Services
{
    public class FastPayService : IFastPayService
    {
        private readonly IRepository repository;

        public FastPayService(IRepository repository)
        {
            this.repository = repository;
        }

        public async Task<Payment> Create(PaymentRequest paymentRequest)
        {
            var payment = await repository.AddAsync(new Payment
            {
                GrossAmount = paymentRequest.Amount,
                Provider = Models.PaymentProvider.FastPay,
                Status = Models.PaymentStatus.Approved,
                Fee = CalculateFee(paymentRequest.Amount),
                NetAmount = paymentRequest.Amount - CalculateFee(paymentRequest.Amount)
            });

            return payment;
        }

        public async Task<FastPay> Create(FastPayRequest fastPayRequest)
        {
            var fastPay = await repository.AddAsync(new FastPay
            {
                Id = $"FP-{new Random().Next(800000,999999)}",
                Status = FastPayStatus.Approved,
                StatusDetail = "Pagamento aprovado",
                TransactionAmount = fastPayRequest.TransactionAmount,
                Currency = fastPayRequest.Currency,
                Payer = fastPayRequest.Payer,
                Installments = fastPayRequest.Installments,
                Description = fastPayRequest.Description
            });

            return fastPay;
        }

        private decimal CalculateFee(decimal amount)
        {
            return Math.Round(((amount / 100) * 3.49m), 2);
        }

        public bool IsAvailable()
        {
            var random = new Random().Next(0,6);
            return random > 3;
        }
    }
}
