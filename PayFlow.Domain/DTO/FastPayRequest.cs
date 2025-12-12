using System.ComponentModel.DataAnnotations;

namespace PayFlow.Domain.DTO
{
    public class Payer
    {
        [Key]
        public string? Email { get; set; }
    }
    public class FastPayRequest
    {
        public decimal TransactionAmount { get; set; }
        public string? Currency { get; set; }
        public Payer? Payer { get; set; }
        public int Installments { get; set; }
        public string? Description { get; set; }
    }
}
