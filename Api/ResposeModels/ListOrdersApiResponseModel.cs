using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Matriks.API.Shared;

namespace Matriks.Api.ResposeModels
{
    [Serializable]
    public class ListOrdersApiResponseModel : Packet
    {
        public string BrokageId { get; set; }

        public string AccountId { get; set; }

        public int ExchangeId { get; set; }

        public List<OrderRequest> OrderApiModels { get; set; }



    }
}
