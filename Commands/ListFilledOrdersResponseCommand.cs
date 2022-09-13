using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Matriks.Api.ResposeModels;
using Matriks.API.Shared;
using Matriks.ApiClient.Api.ResposeModels;
using Matriks.ApiClient.Services;
using Newtonsoft.Json;

namespace Matriks.ApiClient.Commands
{
    public class ListFilledOrdersResponseCommand :ApiCommand
    {
        private TcpCallbackService _tcpCallbackService;
        private ListFilledOrdersApiResponseModel _listFilledOrdersApiResponseModel;
        private IApiPackageService _apiPackageService;
        public ListFilledOrdersResponseCommand(TcpCallbackService tcpCallbackService, IApiPackageService apiPackageService)
        {
            _tcpCallbackService = tcpCallbackService;
            this._apiPackageService = apiPackageService;
        }

        protected override void Deserialize(Packet pack)
        {
            _listFilledOrdersApiResponseModel = _apiPackageService.Deserialize<ListFilledOrdersApiResponseModel>(pack);
        }

        protected override void Execute()
        {
            _tcpCallbackService.ListFilledOrdersResponse(_listFilledOrdersApiResponseModel);
        }

        protected override void UnExecute()
        {
            throw new NotImplementedException();
        }
    }
}
