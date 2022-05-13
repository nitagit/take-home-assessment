using System.Collections.Generic;

namespace Coterie.Api.Models.Responses
{
    public class StatewisePremiums
    {
        public string Business { get; set; }
        public long Revenue { get; set; }
        public List<StatePremium> Premiums { get; set; }
        public bool IsSuccessful { get; set; }
        public string TransactionId { get; set; }

    }
}
