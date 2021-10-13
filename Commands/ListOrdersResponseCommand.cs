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
    public class ListOrdersResponseCommand :ApiCommand
    {
        private TcpCallbackService _tcpCallbackService;
        private ListOrdersApiResponseModel _listOrdersApiResponseModel;
        private IApiPackageService _apiPackageService;
        public ListOrdersResponseCommand(TcpCallbackService tcpCallbackService, IApiPackageService apiPackageService)
        {
            _tcpCallbackService = tcpCallbackService;
            this._apiPackageService = apiPackageService;
        }

        protected override void Deserialize(Packet pack)
        {
            _listOrdersApiResponseModel = _apiPackageService.Deserialize<ListOrdersApiResponseModel>(pack);
        }

        protected override void Execute()
        {
            _tcpCallbackService.ListOrdersResponse(_listOrdersApiResponseModel);
        }

        protected override void UnExecute()
        {
            throw new NotImplementedException();
        }
    }
}
