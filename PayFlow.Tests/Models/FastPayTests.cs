using PayFlow.Domain.Models;
using Xunit;

namespace PayFlow.Tests.Models
{
    public class FastPayTests
    {
        [Fact]
        public void CanCreateFastPayAndSetProperties()
        {
            var f = new FastPay
            {
                Id = "FP-123",
                Status = FastPayStatus.Approved,
                StatusDetail = "ok",
                TransactionAmount = 123.45m,
                Currency = "BRL",
                Installments = 1,
                Description = "desc"
            };

            Assert.Equal("FP-123", f.Id);
            Assert.Equal(FastPayStatus.Approved, f.Status);
            Assert.Equal("ok", f.StatusDetail);
            Assert.Equal(123.45m, f.TransactionAmount);
            Assert.Equal("BRL", f.Currency);
            Assert.Equal(1, f.Installments);
            Assert.Equal("desc", f.Description);
        }
    }
}
