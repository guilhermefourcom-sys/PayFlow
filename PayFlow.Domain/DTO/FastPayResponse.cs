
namespace PayFlow.Domain.DTO
{
    public class FastPayResponse
    {
        public required string Id { get; set; }
        public string? Status { get; set; }
        public string? StatusDetail { get; set; }
    }
}
