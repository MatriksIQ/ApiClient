using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Matriks.API.Shared;

namespace Matriks.Api.ResposeModels
{
    public class OrderApiModel :Packet
    {
        public string BrokageId { get; set; }
        public string AccountId { get; set; }
        public string Symbol { get; set; }
        public string OrderId { get; set; }
        public string OrderId2 { get; set; }
        public int Side { get; set; }
        public decimal OrderQty { get; set; }
        public decimal Price { get; set; }
        public char OrdStatus { get; set; }
        public decimal LeavesQty { get; set; }
        public decimal FilledQty { get; set; }
        public decimal AvgPx { get; set; }
        public DateTime TradeDate { get; set; }
        public TimeSpan TransactTime { get; set; }
        public decimal StopPx { get; set; }
        public string Explanation { get; set; }
        public DateTime ExpireDate { get; set; }
        public char TimeInForce { get; set; }


        public OrderApiModel() { }


    }
}
