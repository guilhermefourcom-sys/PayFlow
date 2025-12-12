namespace PayFlow.Domain.DTO
{
    public class PaymentRequest
    {
        public string? Currency { get; set; }
        public decimal Amount { get; set; }
    }
}
