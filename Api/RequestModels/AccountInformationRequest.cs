using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Matriks.API.Shared;

namespace Matriks.ApiClient.Api.RequestModels
{
    [Serializable]
    public class AccountInformationRequest : Packet
    {
        public string BrokageId { get; set; }
        public string AccountId { get; set; }
        public int ExchangeType { get; set; }
    }
}
