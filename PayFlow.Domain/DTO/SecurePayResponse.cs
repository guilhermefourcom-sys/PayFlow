namespace PayFlow.Domain.DTO
{
    public enum SecurePayResult
    {
        Success
    }
    public class SecurePayResponse
    {
        public string TransactionId { get; set; }
        public string Result { get; set; }
    }
}
