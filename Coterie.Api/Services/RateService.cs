using Coterie.Api.Interfaces;
using Coterie.Api.Models.Requests;
using Coterie.Api.Models.Responses;
using System;
using System.Collections.Generic;

namespace Coterie.Api.Services
{
    public class RateService : IRateService
    {        
        private readonly IDictionary<string, double> _businessFactor = new Dictionary<string, double>(StringComparer.InvariantCultureIgnoreCase)
            {
                {"Architect", 1},
                {"Plumber", 0.5},
                {"Programmer", 1.25}
            };
        private readonly IDictionary<string, double> _stateFactor = new Dictionary<string, double>(StringComparer.InvariantCultureIgnoreCase)
            {
                {"OH", 1},
                {"FL", 1.2},
                {"TX", 0.943}
            };

        private readonly IDictionary<string, string> _stateCodes = new Dictionary<string, string>(StringComparer.InvariantCultureIgnoreCase)
            {
                {"oh", "OH"},
                {"ohio", "OH"},
                {"fl", "FL"},
                {"florida", "FL"},
                {"tx", "TX"},
                {"texas", "TX"}
            };
        public List<StatePremium> GetPremiums(PayloadRequest request)
        {
            return CalculationManager(request);
        }

        private List<StatePremium> CalculationManager(PayloadRequest request)
        {
            var resultDict = new List<StatePremium>();

            foreach (var state in request.states)
            {
                var stateCode = _stateCodes[state];
                var busFact = _businessFactor[request.business];
                var hazardFactor = 4;
                var prem = Math.Ceiling(request.revenue / 1000.0) * _stateFactor[stateCode] * busFact * hazardFactor;
                resultDict.Add(new StatePremium
                {
                    Premium = Math.Round(prem, 2),
                    State = stateCode
                }
                );
            }
            return resultDict;
        }

        
    }
}
