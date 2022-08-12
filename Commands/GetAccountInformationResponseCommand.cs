using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Matriks.API.Shared;
using Matriks.ApiClient.Api.RequestModels;
using Matriks.ApiClient.Api.ResposeModels;
using Matriks.ApiClient.Services;

namespace Matriks.ApiClient.Commands
{
    public class GetAccountInformationResponseCommand : ApiCommand
    {
        private TcpCallbackService _tcpCallbackService;
        private AccountInformationResponseModel accountInformationResponseModel;
        private IApiPackageService _apiPackageService;
        public GetAccountInformationResponseCommand(TcpCallbackService tcpCallbackService, IApiPackageService apiPackageService)
        {
            _tcpCallbackService = tcpCallbackService;
            this._apiPackageService = apiPackageService;
        }

        protected override void Deserialize(Packet pack)
        {
            //orderApiModel = JsonConvert.DeserializeObject<OrderApiModel>(pack.Text);
            accountInformationResponseModel = _apiPackageService.Deserialize<AccountInformationResponseModel>(pack);
        }

        protected override void Execute()
        {
            _tcpCallbackService.GetAccountInformationRecevied(accountInformationResponseModel);
        }

        protected override void UnExecute()
        {
        }
    }
}
