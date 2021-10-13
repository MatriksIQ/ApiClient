using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Matriks.Api;
using Matriks.API.Shared;
using Matriks.ApiClient.Commands;

namespace Matriks.ApiClient.Services
{
    public class ApiCommandFactory
    {
        private readonly IDictionary<ClientCommands, Func<ApiCommand>> _commands;
        private TcpCallbackService _tcpCallbackService;
        private IApiPackageService _apiPackageService;
        public ApiCommandFactory(TcpCallbackService tcpCallbackService, IApiPackageService apiPackageService)
        {
            _tcpCallbackService = tcpCallbackService;
            this._apiPackageService = apiPackageService;
            _commands = new Dictionary<ClientCommands, Func<ApiCommand>>
            {
                {ClientCommands.ListAccountsResponse ,() => new ListAccountsResponseCommand(_tcpCallbackService,apiPackageService)},
                {ClientCommands.ListPositionsResponse ,() => new ListPositionsResponseCommand(_tcpCallbackService,apiPackageService)},
                {ClientCommands.ListOrdersResponse ,() => new ListOrdersResponseCommand(_tcpCallbackService,apiPackageService)},
                {ClientCommands.OrderChangedResponse ,() => new OrderChangedResponseCommand(_tcpCallbackService,apiPackageService)},
                {ClientCommands.PositionChangedResponse ,() => new PositionChangedResponseCommand(_tcpCallbackService,apiPackageService)},
                {ClientCommands.TradeUserLogin ,() => new TradeUserLoginCommand(_tcpCallbackService,apiPackageService)},
                {ClientCommands.TradeUserLogout ,() => new OrderChangedResponseCommand(_tcpCallbackService,apiPackageService)},
                {ClientCommands.KeepAlive, ()=> new KeepAliveCommand(apiPackageService,_tcpCallbackService) }
            };

            
        }

        public ApiCommand GetCommand(Packet packet)
        {
            Func<ApiCommand> command;
            _commands.TryGetValue((ClientCommands)packet.ApiCommands, out command);
            if (command == null)
                return null;
            return command();
        }

    }
}
