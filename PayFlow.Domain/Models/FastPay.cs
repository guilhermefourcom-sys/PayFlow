
using PayFlow.Domain.DTO;
using System.ComponentModel.DataAnnotations;

namespace PayFlow.Domain.Models
{
    public class FastPay
    {
        [Key]
        public required string Id { get; set; }
        public FastPayStatus Status { get; set; }
        public string? StatusDetail { get; set; }
        public decimal TransactionAmount { get; set; }
        public string? Currency { get; set; }
        public Payer? Payer { get; set; }
        public int Installments { get; set; }
        public string? Description { get; set; }
    }

    public enum FastPayStatus
    {
        Approved
    }
}
