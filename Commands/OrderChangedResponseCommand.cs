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
    public class OrderChangedResponseCommand:ApiCommand
    {
        private TcpCallbackService _tcpCallbackService;
        private OrderRequest _orderApiModel;
        private IApiPackageService _apiPackageService;
        public OrderChangedResponseCommand(TcpCallbackService tcpCallbackService, IApiPackageService apiPackageService)
        {
            _tcpCallbackService = tcpCallbackService;
            this._apiPackageService = apiPackageService;
        }


        protected override void Deserialize(Packet pack)
        {
            //orderApiModel = JsonConvert.DeserializeObject<OrderApiModel>(pack.Text);
            _orderApiModel = _apiPackageService.Deserialize<OrderRequest>(pack);
        }

        protected override void Execute()
        {
            _tcpCallbackService.OrderChanged(_orderApiModel);
        }

        protected override void UnExecute()
        {
        }
    }
}
