using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Matriks.Api;

namespace Matriks.MatriksAPI
{
    public class ApiRequest
    {
        public ApiCommands ApiRequestType { get; set; }
        
        public string BrokageId { get; set; }

        public ApiRequest()
        {

        }

    }
}
