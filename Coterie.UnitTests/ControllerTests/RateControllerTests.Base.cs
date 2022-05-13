using Coterie.Api.Controllers;
using Coterie.Api.Interfaces;
using Coterie.Api.Models.Requests;
using Moq;

namespace Coterie.UnitTests.ControllerTests
{
    public partial class RateControllerTests
    {
        private class Base
        {
            public Mock<IRateService> MockRateService { get; } = new Mock<IRateService>();           

            public Base SetupService()
            {
                MockRateService.Setup(x => x.GetPremiums(It.IsAny<PayloadRequest>()))
                .Returns(TestData.PremiumWithState);

                return this;
            }

            public RateController Build()
            {
                return new RateController(MockRateService.Object);
            }
        }
    }
}