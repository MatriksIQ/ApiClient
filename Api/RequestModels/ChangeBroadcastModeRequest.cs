using Matriks.API.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matriks.ApiClient.Api.RequestModels
{
    [Serializable]
    public class ChangeBroadcastModeRequest:Packet
    {
        public int BroadcastMode { get; set; }
        public ChangeBroadcastModeRequest(int broadcastMode)
        {
            BroadcastMode = broadcastMode;
        }
    }
}
