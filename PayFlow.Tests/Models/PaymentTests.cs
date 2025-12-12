using PayFlow.Domain.Models;
using Xunit;

namespace PayFlow.Tests.Models
{
    public class PaymentTests
    {
        [Fact]
        public void CanCreatePaymentAndSetProperties()
        {
            var p = new Payment
            {
                ExternalId = "ext-1",
                Status = PaymentStatus.Approved,
                Provider = PaymentProvider.SecurePay,
                GrossAmount = 100m,
                Fee = 3.49m,
                NetAmount = 96.51m
            };

            Assert.Equal("ext-1", p.ExternalId);
            Assert.Equal(PaymentStatus.Approved, p.Status);
            Assert.Equal(PaymentProvider.SecurePay, p.Provider);
            Assert.Equal(100m, p.GrossAmount);
            Assert.Equal(3.49m, p.Fee);
            Assert.Equal(96.51m, p.NetAmount);
        }
    }
}
