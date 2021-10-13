using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Matriks.MatriksAPI;

namespace Matriks.API.Shared
{
    [Serializable]
    public class OrderRequest : Packet

    {
        //string Symbol, decimal quantity, OrderSide orderSide, ChartIcon chartIcon = ChartIcon.None, bool? includeAfterSession = null

       

        public string Symbol { get; set; }


        public string AccountId { get; set; }

        public string BrokageId { get; set; }

        public decimal Price { get; set; }

        public decimal Quantity { get; set; }

        public int OrderSide { get; set; }

        public string OrderId { get; set; }

        public string OrderId2 { get; set; }

        public string ClientOrderId { get; set; }

        public decimal OrderQty { get; set; }

        public char OrdStatus { get; set; }

        public decimal LeavesQty { get; set; }
        public decimal FilledQty { get; set; }


        public decimal AvgPx { get; set; }
        public DateTime TradeDate { get; set; }
        public TimeSpan TransactTime { get; set; }
        public decimal StopPx { get; set; }
        public string Explanation { get; set; }
        public DateTime ExpireDate { get; set; }    


        public bool IncludeAfterSession { get; set; }

        public char TimeInForce { get; set; }

        public char OrderType { get; set; }

        public char TransactionType { get; set; }

        public OrderRequest() { }

        public OrderRequest(string symbol, string accountId, string brokageId, decimal price, decimal quantity, int orderSide, string orderId, string orderId2, decimal orderQty, char ordStatus, decimal leavesQty, decimal filledQty, decimal avgPx, DateTime tradeDate, TimeSpan transactTime, decimal stopPx, string explanation, DateTime expireDate, bool includeAfterSession, char timeInForce, char orderType, char transactionType)
        {
            Symbol = symbol;
            AccountId = accountId;
            BrokageId = brokageId;
            Price = price;
            Quantity = quantity;
            OrderSide = orderSide;
            OrderId = orderId;
            OrderId2 = orderId2;
            OrderQty = orderQty;
            OrdStatus = ordStatus;
            LeavesQty = leavesQty;
            FilledQty = filledQty;
            AvgPx = avgPx;
            TradeDate = tradeDate;
            TransactTime = transactTime;
            StopPx = stopPx;
            Explanation = explanation;
            ExpireDate = expireDate;
            IncludeAfterSession = includeAfterSession;
            TimeInForce = timeInForce;
            OrderType = orderType;
            TransactionType = transactionType;
        }


    }
}
