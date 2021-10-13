using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Matriks.API.Shared;

namespace Matriks.Api
{
    [Serializable]
    public class ListPositionsApiModel:Packet
    {
        public string BrokageId { get; set; }

        public string AccountId { get; set; }

        public int ExchangeId { get; set; }

        public ListPositionsApiModel() { }

        public ListPositionsApiModel(string brokageId, string accountId,int exchangeId)
        {
            this.BrokageId = brokageId;
            this.AccountId = accountId;
            this.ExchangeId = exchangeId;
        }
    }
}
