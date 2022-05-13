using Coterie.Api.Services;
using NUnit.Framework;
using System.Linq;

namespace Coterie.UnitTests.ServiceTests
{
    [TestFixture]
    public partial class RateServiceTests
    {
        protected RateService RateService;

        [OneTimeSetUp]
        public void BaseOneTimeSetup()
        {
            RateService = new RateService();
        }       

        [Test]
        public void GetPremiums_WhenRequestIsValid_ReturnsTotalPayload()
        {
            var actualPremiums = RateService.GetPremiums(TestData.request);

            // Assert
            Assert.IsNotNull(actualPremiums);
            foreach (var (expected, actual) in actualPremiums.Zip(TestData.Premiums))
            {
                Assert.That(expected.State, Is.EqualTo(actual.State));
                Assert.That(expected.Premium, Is.EqualTo(actual.Premium));
            }           
        }

        [Test]
        public void GetPremiums_WhenRequestedFullStateName_ReturnsTotalPayloadWithState()
        {
            var request = TestData.request;
            request.states = TestData.states;           

            var actualPremiums = RateService.GetPremiums(request);

            // Assert
            Assert.IsNotNull(actualPremiums);
            foreach (var (expected, actual) in actualPremiums.Zip(TestData.Premiums))
            {
                Assert.That(expected.State, Is.EqualTo(actual.State));
                Assert.That(expected.Premium, Is.EqualTo(actual.Premium));
            }
        }

    }
}

