using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Matriks.API.Shared;
namespace Matriks.Api.ResposeModels
{


    [Serializable]
    public class PositionResponseModel : Packet
    {
        public string BrokageId { get; set; }

        public string AccountId { get; set; }

        public string Symbol { get; set; }

        public int PositionId { get; set; }

        public string Currency { get; set; }

        public decimal QtyT { get; set; }

        public decimal QtyT1 { get; set; }

        public decimal QtyT2 { get; set; }

        public decimal QtyT3 { get; set; }

        public string QtyTFormatted { get; set; }

        public string QtyT1Formatted { get; set; }

        public string QtyT2Formatted { get; set; }

        public string QtyT3Formatted { get; set; }

        public decimal? LastPx { get; set; }

        public decimal? DayChange1 { get; set; }

        public decimal? DayChange2 { get; set; }

        public string LastPxFormatted { get; set; }

        public decimal Amount { get; set; }

        public string AmountFormatted { get; set; }

        public decimal QtyAvailable { get; set; }

        public decimal AvgCost { get; set; }

        public string AvgCostFormatted { get; set; }

        public decimal OpeningAveragePrice { get; set; }

        public decimal Pl { get; set; }

        public string PlFormatted { get; set; }

        public decimal PlPercent { get; set; }

        public decimal Credit { get; set; }

        public bool RemovePosition { get; set; }

        public bool IsTpsl { get; set; }

        public bool IsTradingSl { get; set; }

        public bool HasAlert { get; set; }

        public int Side { get; set; }

        public bool IsSymbol { set; get; }

        public int ExchangeId { get; set; }

        public bool IsSelected { get; set; }

        //Viop Sozlesmeleri icin yeni eklenen property ler

        public System.DateTime RecordDate { get; set; }

        public string SideDescription { get; set; }

        public decimal QtyLong { get; set; }

        public decimal QtyShort { get; set; }

        public decimal QtyNet { get; set; }

        public decimal SettlementPx { get; set; }

        public decimal PlUr { get; set; }

        public decimal PlR { get; set; }

        public decimal TotalPosition { get; set; }

        public decimal NetTotal { get; set; }

        public string QtyAvailableFormatted { get; set; }

        public decimal PlBridge { get; set; }

        public decimal PriceBridge { get; set; }

        public decimal PlPercentBridge { get; set; }

        public string OpeningAveragePriceString { get; set; }

        public decimal PositionAmount { get; set; }

        public string PositionAmountFormatted { get; set; }

        public decimal? CompromisePrice { get; set; }

        public string CompromisePriceFormatted { get; set; }

        public string ClosingDate { get; set; }

        //Binance Futures alanları
        public decimal EntryPrice { get; set; }
        public decimal InitialMargin { get; set; }
        public bool Isolated { get; set; }
        public decimal Leverage { get; set; }
        public decimal MaintMargin { get; set; }
        public decimal MaxNotional { get; set; }
        public decimal OpenOrderInitialMargin { get; set; }
        public decimal PositionInitialMargin { get; set; }
    }
}
