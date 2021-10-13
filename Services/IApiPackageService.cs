using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Matriks.API.Shared;

namespace Matriks.ApiClient.Services
{
    public interface IApiPackageService
    {
        object Serialize(object obj);
        T Deserialize<T>(Packet data);
    }
}
