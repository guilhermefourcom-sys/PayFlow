namespace PayFlow.Domain.DTO
{
    public class SecurePayRequest
    {
        public int AmountCents { get; set; }
        public string? CurrencyCode { get; set; }
        public string? ClientReference { get; set; }
    }
}
