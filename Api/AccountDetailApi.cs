using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matriks.Api
{
    [Serializable]
    public class AccountDetailApi
    {
        public string CustomerId { get; set; }
        public string DefaultAccount { get; set; }
        public IEnumerable<string> AccountList { get; set; }
        public string BrokerageId { get; set; }

    }
}
