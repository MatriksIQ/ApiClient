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
    public class ChangeLoggingModeResponseCommand : ApiCommand
    {
        private TcpCallbackService _tcpCallbackService;
        private ChangeLoggingModeResponseModel _changeLoggingModeResponseModel;
        private IApiPackageService _apiPackageService;

        public ChangeLoggingModeResponseCommand(TcpCallbackService tcpCallbackService, IApiPackageService apiPackageService)
        {
            _tcpCallbackService = tcpCallbackService;
            _apiPackageService = apiPackageService;
        }

        protected override void Deserialize(Packet pack)
        {
            _changeLoggingModeResponseModel = _apiPackageService.Deserialize<ChangeLoggingModeResponseModel>(pack);
        }

        protected override void Execute()
        {
            _tcpCallbackService.ChangeLoggingModeResponse(_changeLoggingModeResponseModel);
        }

        protected override void UnExecute()
        {
            throw new NotImplementedException();
        }
    }
}
