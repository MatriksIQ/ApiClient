using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Matriks.Api;
using Matriks.Api.RequestModels;
using Matriks.Api.ResposeModels;
using Matriks.API.Shared;
using Matriks.ApiClient.Api.ResposeModels;

namespace Matriks.ApiClient
{
    public class TcpCallbackService
    {
        public event EventHandler<List<BrokageAccounts>> ListAccountsResponseEvent;

        public event EventHandler<ListPositionResponseModel> ListPositionsResponseEvent;

        public event EventHandler<ListOrdersApiResponseModel> ListOrdersResponseEvent;
		
        public event EventHandler<ListFilledOrdersApiResponseModel> ListFilledOrdersResponseEvent;
		
        public event EventHandler<ListCanceledOrdersApiResponseModel> ListCanceledOrdersResponseEvent;

        public event EventHandler<OrderRequest> OrderChangedEvent;

        public event EventHandler<PositionResponseModel> PositionChangedEvent;

        public event EventHandler<TradeUserLoginModel> TradeUserLoginEvent;

        public event EventHandler<TradeUserLogoutModel> TraderUserLogoutEvent;

        public event EventHandler<KeepAlive> KeepAliveResponseEvent;

        public event EventHandler<AccountInformationResponseModel> GetAccountInformationResponseEvent;

        public event EventHandler<ChangeLoggingModeResponseModel> ChangeLoggingModeResponseEvent;

        public event EventHandler<ChangeBroadcastModeResponseModel> ChangeBroadcastModeResponseEvent;

        public void KeepAliveResponse(KeepAlive keepAlive)
        {
            KeepAliveResponseEvent.Invoke(this,keepAlive);
        }

        public void OrderChanged(OrderRequest orderApiModel)
        {
            if (OrderChangedEvent != null) OrderChangedEvent(this, orderApiModel);
        }

        public void ListOrdersResponse(ListOrdersApiResponseModel listOrdersApiResponseModel)
        {
            var handler = ListOrdersResponseEvent;
            if (handler != null)
            {
                handler(this, listOrdersApiResponseModel);
            }
        }

        public void ListFilledOrdersResponse(ListFilledOrdersApiResponseModel listFilledOrdersApiResponseModel)
        {
            var handler = ListFilledOrdersResponseEvent;
            if (handler != null)
            {
                handler(this, listFilledOrdersApiResponseModel);
            }
        }

        public void ListCanceledOrdersResponse(ListCanceledOrdersApiResponseModel listCanceledOrdersApiResponseModel)
        {
            var handler = ListCanceledOrdersResponseEvent;
            if (handler != null)
            {
                handler(this, listCanceledOrdersApiResponseModel);
            }
        }

        public void ListAccountsResponse(List<BrokageAccounts> brokerAccountses)
        {
            var handler = ListAccountsResponseEvent;
            if (handler != null)
            {
                handler(this, brokerAccountses);
            }
        }

        public void ListPositionsResponse(ListPositionResponseModel listPositionResponseModel)
        {
            var handler = ListPositionsResponseEvent;
            if (handler != null)
            {
                handler(this, listPositionResponseModel);
            }
        }

        public void PositionChanged(PositionResponseModel positionResponseModel)
        {
            if (PositionChangedEvent != null) PositionChangedEvent(this, positionResponseModel);
        }

        public void TradeUserLoggedIn(TradeUserLoginModel tradeUserLoginModel)
        {
            if (TradeUserLoginEvent != null) TradeUserLoginEvent(this, tradeUserLoginModel);
        }

        public void TradeUserLoggedOut(TradeUserLogoutModel tradeUserLogoutModel)
        {
            if (TraderUserLogoutEvent != null) TraderUserLogoutEvent(this, tradeUserLogoutModel);
        }

        public void GetAccountInformationRecevied(AccountInformationResponseModel accountInformationResponseModel)
        {
            if (GetAccountInformationResponseEvent != null) GetAccountInformationResponseEvent(this, accountInformationResponseModel);
        }
        public void ChangeLoggingModeResponse(ChangeLoggingModeResponseModel changeLoggingModeResponseModel)
        {
            if (ChangeLoggingModeResponseEvent != null) ChangeLoggingModeResponseEvent(this, changeLoggingModeResponseModel);
        }
        public void ChangeBroadcastModeResponse(ChangeBroadcastModeResponseModel changeBroadcastModeResponseModel)
        {
            if (ChangeBroadcastModeResponseEvent != null) ChangeBroadcastModeResponseEvent(this, changeBroadcastModeResponseModel);
        }

        public void Connect(string ip, int port)
        {
        }
    }
}
