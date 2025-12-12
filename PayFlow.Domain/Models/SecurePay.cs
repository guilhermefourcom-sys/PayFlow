using System.ComponentModel.DataAnnotations;

namespace PayFlow.Domain.Models
{
    public class SecurePay
    {
        [Key]
        public required string Id { get; set; }
        public int AmountCents { get; set; }
        public string? CurrencyCode { get; set; }
        public string? ClientReference { get; set; }
    }
}
