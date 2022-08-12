﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matriks.Api
{
    public enum ApiCommands
    {
        ListAccounts,
        ListPositions,
        ListOrders,
        NewOrder,
        CancelOrder,
        EditOrder,
        KeepAlive,
        GetAccountInformation
    }

    public enum ClientCommands
    {
        ListAccountsResponse,
        ListPositionsResponse,
        ListOrdersResponse,
        OrderChangedResponse,
        PositionChangedResponse,
        TradeUserLogin,
        TradeUserLogout,
        KeepAlive,
        GetAccountInformationResponse
    }

    public enum DataType
    {
        Json,
        MessagePack
    }


}
