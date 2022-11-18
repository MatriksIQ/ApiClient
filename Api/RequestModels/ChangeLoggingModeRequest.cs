using Matriks.API.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matriks.ApiClient.Api.RequestModels
{
    [Serializable]
    public class ChangeLoggingModeRequest:Packet
    {
        public int LoggingMode { get; set; }
        public ChangeLoggingModeRequest(int loggingMode)
        {
            LoggingMode = loggingMode;
        }
    }
}
