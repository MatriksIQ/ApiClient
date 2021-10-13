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
    public class PositionChangedResponseCommand:ApiCommand
    {
        private TcpCallbackService _tcpCallbackService;
        private PositionResponseModel _positionResponseModel;
        private IApiPackageService _apiPackageService;
        public PositionChangedResponseCommand(TcpCallbackService tcpCallbackService, IApiPackageService apiPackageService)
        {
            _tcpCallbackService = tcpCallbackService;
            this._apiPackageService = apiPackageService;
        }


        protected override void Deserialize(Packet pack)
        {
            //positionResponseModel = JsonConvert.DeserializeObject<PositionResponseModel>(pack.Text);
            _positionResponseModel = _apiPackageService.Deserialize<PositionResponseModel>(pack);
        }

        protected override void Execute()
        {
            _tcpCallbackService.PositionChanged(_positionResponseModel);
        }

        protected override void UnExecute()
        {
        }

       
    }
}
