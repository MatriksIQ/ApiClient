using Matriks.API.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matriks.ApiClient.Api.ResposeModels
{
    [Serializable]
    public class ChangeBroadcastModeResponseModel : Packet
    {
        public string Message { get; set; }
        public int BroadcastMode { get; set; }
    }
}
