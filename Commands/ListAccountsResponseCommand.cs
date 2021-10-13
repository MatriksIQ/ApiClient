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
    public class ListAccountsResponseCommand:ApiCommand
    {
        private TcpCallbackService _tcpCallbackService;
        private ListAccountsPacket _listAccountsPacket;
        private IApiPackageService _apiPackageService;
        public ListAccountsResponseCommand(TcpCallbackService tcpCallbackService, IApiPackageService apiPackageService)
        {
            _tcpCallbackService = tcpCallbackService;
            this._apiPackageService = apiPackageService;
        }

        protected override void Deserialize(Packet pack)
        {
            _listAccountsPacket =_apiPackageService.Deserialize<ListAccountsPacket>(pack);
            //listAccountsPacket = JsonConvert.DeserializeObject<ListAccountsPacket>(pack.Text);
        }

        protected override void Execute()
        {
            _tcpCallbackService.ListAccountsResponse(_listAccountsPacket.Accounts);
        }

        protected override void UnExecute()
        {
            throw new NotImplementedException();
        }
    }
}
