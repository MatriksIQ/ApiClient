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
    public class TradeUserLoginCommand : ApiCommand
    {
        private TcpCallbackService _tcpCallbackService;
        private TradeUserLoginModel _tradeUserLoginModel;
        private IApiPackageService _apiPackageService;
        public TradeUserLoginCommand(TcpCallbackService tcpCallbackService, IApiPackageService apiPackageService)
        {
            this._tcpCallbackService = tcpCallbackService;
            this._apiPackageService = apiPackageService;
        }

        protected override void Deserialize(Packet pack)
        {
            //tradeUserLoginModel = JsonConvert.DeserializeObject<TradeUserLoginModel>(pack.Text);
            _tradeUserLoginModel = _apiPackageService.Deserialize<TradeUserLoginModel>(pack);
        }

        protected override void Execute()
        {
            _tcpCallbackService.TradeUserLoggedIn(_tradeUserLoginModel);
        }

        protected override void UnExecute()
        {
            
        }
    }
}
