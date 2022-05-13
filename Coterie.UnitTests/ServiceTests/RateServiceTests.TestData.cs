using Coterie.Api.Models.Requests;
using Coterie.Api.Models.Responses;
using System.Collections.Generic;

namespace Coterie.UnitTests.ServiceTests
{
    public partial class RateServiceTests
    {
        private static class TestData
        {
            public static PayloadRequest request = 
                new PayloadRequest
                {
                    business = "Plumber",
                    revenue = 6000000,
                    states = new List<string>
                            {
                                "OH", "Tx", "FL"
                            }
                };

            public static List<string> states =
                new List<string>
                {
                    "Ohio", "Texas", "FLorida"
                };

            public static List<StatePremium> Premiums = 
                new List<StatePremium>
                {
                    new StatePremium
                    {
                        Premium = 12000,
                        State = "OH"
                    },
                    new StatePremium
                    {
                        Premium = 11316,
                        State = "TX"
                    },new StatePremium
                    {
                        Premium = 14400,
                        State = "FL"
                    }
                };
        }        
    }
}