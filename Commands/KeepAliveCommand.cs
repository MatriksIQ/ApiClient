using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Matriks.Api.RequestModels;
using Matriks.API.Shared;
using Matriks.ApiClient.Services;

namespace Matriks.ApiClient.Commands
{
    public class KeepAliveCommand : ApiCommand
    {

        private TcpCallbackService _tcpCallbackService;
        private IApiPackageService _apiPackageService;
        private KeepAlive _keepAlive;
        public KeepAliveCommand(IApiPackageService apiPackageService, TcpCallbackService tcpCallbackService)
        {
            this._apiPackageService = apiPackageService;
            _tcpCallbackService = tcpCallbackService;
        }

        protected override void Deserialize(Packet pack)
        {
            _keepAlive=_apiPackageService.Deserialize<KeepAlive>(pack);
        }

        protected override void Execute()
        {
            _tcpCallbackService.KeepAliveResponse(_keepAlive);
        }

        protected override void UnExecute()
        {
            throw new NotImplementedException();
        }
    }
}
