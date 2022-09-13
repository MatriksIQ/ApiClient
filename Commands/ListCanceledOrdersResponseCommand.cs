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
    public class ListCanceledOrdersResponseCommand :ApiCommand
    {
        private TcpCallbackService _tcpCallbackService;
        private ListCanceledOrdersApiResponseModel _listCanceledOrdersApiResponseModel;
        private IApiPackageService _apiPackageService;
        public ListCanceledOrdersResponseCommand(TcpCallbackService tcpCallbackService, IApiPackageService apiPackageService)
        {
            _tcpCallbackService = tcpCallbackService;
            this._apiPackageService = apiPackageService;
        }

        protected override void Deserialize(Packet pack)
        {
            _listCanceledOrdersApiResponseModel = _apiPackageService.Deserialize<ListCanceledOrdersApiResponseModel>(pack);
        }

        protected override void Execute()
        {
            _tcpCallbackService.ListCanceledOrdersResponse(_listCanceledOrdersApiResponseModel);
        }

        protected override void UnExecute()
        {
            throw new NotImplementedException();
        }
    }
}