using Coterie.Api.Models.Requests;
using Moq;
using NUnit.Framework;
using System;

namespace Coterie.UnitTests.ControllerTests
{
    [TestFixture]
    public partial class RateControllerTests
    {
        [Test]
        public void GetTotalPremium_WhenRequestIsValid_ReturnsTotalPayload()
        {
            var builder = new Base().SetupService();
            var controller = builder.Build();

            var actual = controller.GetTotalPremium(TestData.request);

            // Assert
            var requestData = TestData.request;
            Assert.IsNotNull(actual);
            var actualValue = actual.Value.Item;
            Assert.That(actualValue.Business, Is.EqualTo(requestData.business));
            Assert.That(actualValue.Revenue, Is.EqualTo(requestData.revenue));
            Assert.That(actualValue.Premiums.Count, Is.GreaterThan(0));
            builder.MockRateService.Verify(x => x.GetPremiums(It.IsAny<PayloadRequest>()), Times.AtLeastOnce);
        }

        [Test]
        public void GetTotalPremium_WhenRequestIsNull_ThrowsInvalidOperationException()
        {
            var builder = new Base();
            var controller = builder.Build();

            PayloadRequest request = null;

            // Assert
            Assert.Throws<InvalidOperationException>(() => controller.GetTotalPremium(request));            
            builder.MockRateService.Verify(x => x.GetPremiums(It.IsAny<PayloadRequest>()), Times.Never);
        }

        [Test]
        public void GetTotalPremium_WhenBusinessIsNotValid_ThrowsInvalidOperationException()
        {
            var builder = new Base();
            var controller = builder.Build();

            var request = TestData.request;
            request.business = "Manager";

            // Assert
            Assert.Throws<InvalidOperationException>(() => controller.GetTotalPremium(request));
            builder.MockRateService.Verify(x => x.GetPremiums(It.IsAny<PayloadRequest>()), Times.Never);
        }

        [Test]
        public void GetTotalPremium_WhenStateIsNotValid_ThrowsInvalidOperationException()
        {
            var builder = new Base();
            var controller = builder.Build();

            var request = TestData.request;
            request.states.Add("NY");

            // Assert
            Assert.Throws<InvalidOperationException>(() => controller.GetTotalPremium(request));
            builder.MockRateService.Verify(x => x.GetPremiums(It.IsAny<PayloadRequest>()), Times.Never);
        }

        [Test]
        public void GetTotalPremium_WhenRevenueIsNegative_ThrowsInvalidOperationException()
        {
            var builder = new Base();
            var controller = builder.Build();

            var request = TestData.request;
            request.revenue = -1;

            // Assert
            Assert.Throws<InvalidOperationException>(() => controller.GetTotalPremium(request));
            builder.MockRateService.Verify(x => x.GetPremiums(It.IsAny<PayloadRequest>()), Times.Never);
        }
    }
}
