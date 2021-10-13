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
    public class TradeUserLogoutCommand :ApiCommand
    {
        private TcpCallbackService _tcpCallbackService;
        private TradeUserLogoutModel _tradeUserLogoutModel;
        private IApiPackageService _apiPackageService;
        public TradeUserLogoutCommand(TcpCallbackService tcpCallbackService, IApiPackageService apiPackageService)
        {
            this._tcpCallbackService = tcpCallbackService;
            this._apiPackageService = apiPackageService;
        }

        protected override void Deserialize(Packet pack)
        {
            _tradeUserLogoutModel = _apiPackageService.Deserialize<TradeUserLogoutModel>(pack);
        }

        protected override void Execute()
        {
            _tcpCallbackService.TradeUserLoggedOut(_tradeUserLogoutModel);
        }

        protected override void UnExecute()
        {
            throw new NotImplementedException();
        }
    }
}
