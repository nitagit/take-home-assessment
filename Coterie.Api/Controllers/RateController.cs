using Coterie.Api.Interfaces;
using Coterie.Api.Models.Requests;
using Coterie.Api.Models.Responses;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Coterie.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RateController : ControllerBase
    {
        private readonly HashSet<string> _businesses = new HashSet<string>(StringComparer.InvariantCultureIgnoreCase)
        {
            "Plumber",
            "Architect",
            "Programmer"
        };

        private readonly HashSet<string> _states = new HashSet<string>(StringComparer.InvariantCultureIgnoreCase)
        {
            "oh", 
            "tx", 
            "fl", 
            "ohio", 
            "texas", 
            "florida"
        };

        private readonly IRateService _rateService;
        public RateController(IRateService rateService)
        {
            _rateService = rateService;
        }      

        [HttpPost]
        public StatewisePremiums GetTotalPremium([FromBody] PayloadRequest request)
        {
            ValidateRequest(request);

            var premium = _rateService.GetPremiums(request);

            var result = new StatewisePremiums
            {
                Business = request.business,
                Revenue = request.revenue,
                Premiums = premium,
                IsSuccessful = true,
                TransactionId = Guid.NewGuid().ToString()
            };

            return result;
        }

        private void ValidateRequest(PayloadRequest request)
        {
            if (request == null)
            {
                throw new InvalidOperationException("request input parameter is null");
            }

            if(!_businesses.Contains(request.business))
            {
                throw new InvalidOperationException($"{request.business} is invalid business");
            }
            
            foreach(var state in request.states)
            {
                if (!_states.Contains(state.ToLower()))
                {
                    throw new InvalidOperationException($"{state} is invalid state");
                }
            }            
        }
    }
}
