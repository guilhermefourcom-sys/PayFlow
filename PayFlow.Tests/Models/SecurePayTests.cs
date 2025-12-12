using PayFlow.Domain.Models;
using Xunit;

namespace PayFlow.Tests.Models
{
    public class SecurePayTests
    {
        [Fact]
        public void CanCreateSecurePayAndSetProperties()
        {
            var s = new SecurePay
            {
                Id = "SP-1",
                AmountCents = 10000,
                CurrencyCode = "BRL",
                ClientReference = "ref"
            };

            Assert.Equal("SP-1", s.Id);
            Assert.Equal(10000, s.AmountCents);
            Assert.Equal("BRL", s.CurrencyCode);
            Assert.Equal("ref", s.ClientReference);
        }
    }
}
