using Coterie.Api.Models.Requests;
using Coterie.Api.Models.Responses;
using System.Collections.Generic;

namespace Coterie.UnitTests.ControllerTests
{
    public partial class RateControllerTests
    {
        private class TestData
        {
            public static PayloadRequest request = new PayloadRequest
            {
                business = "Plumber",
                revenue = 6000000,
                states = new List<string>
                {
                    "OH"
                }
            };

            public static StatewisePremiums response = 
                new StatewisePremiums
                {
                    Business = "Plumber",
                    Revenue = 6000000,
                    Premiums = new List<StatePremium>
                                {
                                    new StatePremium
                                    {
                                        Premium = 12000,
                                        State = "OH"
                                    }
                                }
                };

            public static List<StatePremium> PremiumWithState =
                new List<StatePremium>
                {
                    new StatePremium
                    {
                        Premium = 12000,
                        State = "OH"
                    }
                };
        }
    }
}
