using Matriks.ApiClient.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Matriks.API.Shared;
using Matriks.ApiClient.Api.ResposeModels;

namespace Matriks.ApiClient.Commands
{
    public class ChangeBroadcastModeResponseCommand : ApiCommand
    {
        private TcpCallbackService _tcpCallbackService;
        private ChangeBroadcastModeResponseModel _changeBroadcastModeResponseModel;
        private IApiPackageService _apiPackageService;

        public ChangeBroadcastModeResponseCommand(TcpCallbackService tcpCallbackService, IApiPackageService apiPackageService)
        {
            _tcpCallbackService = tcpCallbackService;
            _apiPackageService = apiPackageService;
        }

        protected override void Deserialize(Packet pack)
        {
            _changeBroadcastModeResponseModel = _apiPackageService.Deserialize<ChangeBroadcastModeResponseModel>(pack);
        }

        protected override void Execute()
        {
            _tcpCallbackService.ChangeBroadcastModeResponse(_changeBroadcastModeResponseModel);
        }

        protected override void UnExecute()
        {
            throw new NotImplementedException();
        }
    }
}
