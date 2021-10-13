using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Matriks.API.Shared;

namespace Matriks.Api.RequestModels
{
    public class ListOrdersApiRequest:Packet
    {
        public string BrokageId { get; set; }

        public string AccountId { get; set; }

        public int ExchangeId { get; set; }

        public ListOrdersApiRequest() { }

        public ListOrdersApiRequest(string brokageId, string accountId, int exchangeType)
        {
            this.BrokageId = brokageId;
            this.AccountId = accountId;
            this.ExchangeId = exchangeType;
        }
    }
}
