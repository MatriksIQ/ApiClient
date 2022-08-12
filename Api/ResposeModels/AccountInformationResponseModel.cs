using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Matriks.API.Shared;
using Matriks.ApiClient.Api.RequestModels;

namespace Matriks.ApiClient.Api.ResposeModels
{
    public class AccountInformationModel
    {
        public string Code { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
        public int? DataType { get; set; }
    }

    [Serializable]
    public class AccountInformationResponseModel : Packet
    {
        public List<AccountInformationModel> Informations { get; set; }
        public AccountInformationRequest Request { get; set; }
    }
}
