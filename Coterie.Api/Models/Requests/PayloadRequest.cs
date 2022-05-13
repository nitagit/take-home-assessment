using System;
using System.Collections.Generic;

namespace Coterie.Api.Models.Requests
{
    public class PayloadRequest
    {        
        public string business { get; set; }
        public long revenue { get; set; }
        public List<string> states { get; set; }
    }
}
