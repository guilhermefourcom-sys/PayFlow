using System.ComponentModel.DataAnnotations;

namespace PayFlow.Domain.Models
{
    public class Payment
    {
        [Key]
        public int Id { get; set; }
        public string? ExternalId { get; set; }
        public PaymentStatus Status { get; set; }
        public PaymentProvider Provider { get; set; }
        public decimal GrossAmount { get; set; }
        public decimal Fee { get; set; }
        public decimal NetAmount { get; set; }

    }

    public enum PaymentStatus
    {
        Approved
    }

    public enum PaymentProvider
    {
        SecurePay,
        FastPay
    }
}
