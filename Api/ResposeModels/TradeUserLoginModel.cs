using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Matriks.API.Shared;

namespace Matriks.Api.ResposeModels
{
    [Serializable]
    public class TradeUserLoginModel:Packet
    {
        public string AccountId { get; set; }

        public string BrokageId { get; set; }

        public string BrokageName { get; set; }

        public int ExchangeId { get; set; }
    }
}
