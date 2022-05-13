using Coterie.Api.Models.Requests;
using Coterie.Api.Models.Responses;
using System.Collections.Generic;

namespace Coterie.Api.Interfaces
{
    public interface IRateService
    {
        List<StatePremium> GetPremiums(PayloadRequest request);
    }
}
