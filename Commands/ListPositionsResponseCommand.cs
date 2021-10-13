using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Matriks.Api.ResposeModels;
using Matriks.API.Shared;
using Matriks.ApiClient.Services;
using Newtonsoft.Json;

namespace Matriks.ApiClient.Commands
{
    public class ListPositionsResponseCommand:ApiCommand
    {
        private ListPositionResponseModel _listPositionResponseModel;
        private TcpCallbackService _tcpCallbackService;
        private IApiPackageService _apiPackageService;
        public ListPositionsResponseCommand(TcpCallbackService tcpCallbackService, IApiPackageService apiPackageService)
        {
            this._tcpCallbackService = tcpCallbackService;
            this._apiPackageService = apiPackageService;
        }
        protected override void Deserialize(Packet pack)
        {
            _listPositionResponseModel = _apiPackageService.Deserialize<ListPositionResponseModel>(pack);
        }

        protected override void Execute()
        {
            _tcpCallbackService.ListPositionsResponse(_listPositionResponseModel);
        }

        protected override void UnExecute()
        {
            throw new NotImplementedException();
        }
    }
}
