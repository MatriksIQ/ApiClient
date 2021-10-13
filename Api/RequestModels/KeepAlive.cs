using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Matriks.API.Shared;

namespace Matriks.Api.RequestModels
{
    [Serializable]
    public class KeepAlive : Packet
    {
        public DateTime KeepAliveDate { get; set; }
    }
}