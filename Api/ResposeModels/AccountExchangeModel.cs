using System;

namespace Matriks.ApiClient.Api.ResposeModels
{
    [Serializable]
    public class AccountExchangeModel
    {
        public string AccountId { get; set; }

        public int ExchangeId { get; set; }

        public AccountExchangeModel() { }

        public AccountExchangeModel(string accountId, int exchangeId)
        {
            this.AccountId = accountId;
            this.ExchangeId = exchangeId;
        }
    }
}