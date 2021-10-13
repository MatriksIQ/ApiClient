using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Matriks.Api.ResposeModels;
using Matriks.API.Shared;
using Matriks.ApiClient.Api.ResposeModels;

namespace Matriks.Api
{
    [Serializable]
    public class BrokageAccounts
    {
        public string BrokageId { get; set; }

        public string BrokageName { get; set; }

        public List<AccountExchangeModel> AccountIdList { get; set; }

        public BrokageAccounts() { }

        public BrokageAccounts(string brokerId, string brokageName, List<AccountExchangeModel> accountIdList)
        {
            this.BrokageId = brokerId;
            this.BrokageName = brokageName;
            this.AccountIdList = accountIdList;
        }

    }
}