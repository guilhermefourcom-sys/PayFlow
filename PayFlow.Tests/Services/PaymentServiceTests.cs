using Moq;
using PayFlow.Domain.DTO;
using PayFlow.Domain.Interfaces;
using PayFlow.Domain.Models;
using PayFlow.Domain.Services;
using System.Threading.Tasks;
using Xunit;

namespace PayFlow.Tests.Services
{
    public class PaymentServiceTests
    {
        [Fact]
        public async Task Create_UsesFastPay_WhenAmountLessThan100AndFastPayAvailable()
        {
            var fastMock = new Mock<IFastPayService>();
            var secureMock = new Mock<ISecurePayService>();

            fastMock.Setup(f => f.IsAvailable()).Returns(true);
            fastMock.Setup(f => f.Create(It.IsAny<PaymentRequest>())).ReturnsAsync((PaymentRequest r) => new Payment { GrossAmount = r.Amount });

            var service = new PaymentService(secureMock.Object, fastMock.Object);

            var req = new PaymentRequest { Amount = 50m };

            var result = await service.Create(req);

            Assert.Equal(50m, result.GrossAmount);
        }

        [Fact]
        public async Task Create_UsesSecurePay_WhenFastPayNotAvailableAndAmountGreaterThan100()
        {
            var fastMock = new Mock<IFastPayService>();
            var secureMock = new Mock<ISecurePayService>();

            fastMock.Setup(f => f.IsAvailable()).Returns(false);
            secureMock.Setup(s => s.IsAvailable()).Returns(false);
            fastMock.Setup(f => f.Create(It.IsAny<PaymentRequest>())).ReturnsAsync((PaymentRequest r) => new Payment { GrossAmount = r.Amount });
            secureMock.Setup(s => s.Create(It.IsAny<PaymentRequest>())).ReturnsAsync((PaymentRequest r) => new Payment { GrossAmount = r.Amount });

            var service = new PaymentService(secureMock.Object, fastMock.Object);

            var req = new PaymentRequest { Amount = 150m };

            var result = await service.Create(req);

            Assert.Equal(150m, result.GrossAmount);
        }
    }
}
