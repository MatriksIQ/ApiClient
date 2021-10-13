using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Matriks.API.Shared;

namespace Matriks.ApiClient.Services
{
    public class PacketRouter:IPacketRouter
    {
        private ApiCommandFactory _apiCommandFactory = null;
        private TcpCallbackService _tcpCallbackService;
        private IApiPackageService _apiPackageService;
        public PacketRouter(TcpCallbackService tcpCallbackService, IApiPackageService apiPackageService)
        {
            _tcpCallbackService = tcpCallbackService;
            this._apiPackageService = apiPackageService;
            _apiCommandFactory = new ApiCommandFactory(_tcpCallbackService, apiPackageService);
        }

        public void Compute(Packet packet)
        {
            var command = _apiCommandFactory.GetCommand(packet);
            if (command != null)
            {
                 command.Run(packet);
            }
            else
            {
            }
        }
    }
}
