using Moq;
using PayFlow.Domain.DTO;
using PayFlow.Domain.Interfaces;
using PayFlow.Domain.Models;
using PayFlow.Domain.Services;
using System.Threading.Tasks;
using Xunit;

namespace PayFlow.Tests.Services
{
    public class FastPayServiceTests
    {
        [Fact]
        public async Task Create_WhenCalled_WithPaymentRequest_ReturnsPaymentWithCalculatedFee()
        {
            var repoMock = new Mock<IRepository>();
            repoMock
                .Setup(r => r.AddAsync(It.IsAny<Payment>()))
                .ReturnsAsync((Payment p) => p);

            var service = new FastPayService(repoMock.Object);

            var req = new PaymentRequest { Amount = 100m };

            var result = await service.Create(req);

            Assert.Equal(100m, result.GrossAmount);
            Assert.Equal(3.49m, result.Fee);
            Assert.Equal(96.51m, result.NetAmount);
            Assert.Equal(PaymentProvider.FastPay, result.Provider);
        }
    }
}
