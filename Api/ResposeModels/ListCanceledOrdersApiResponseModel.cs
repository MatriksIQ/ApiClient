using Matriks.API.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matriks.ApiClient.Api.ResposeModels
{
    [Serializable]
    public class ListCanceledOrdersApiResponseModel : Packet
    {
        public string BrokageId { get; set; }

        public string AccountId { get; set; }

        public int ExchangeID { get; set; }

        public List<OrderRequest> CanceledOrderApiModels { get; set; }
    }
}
