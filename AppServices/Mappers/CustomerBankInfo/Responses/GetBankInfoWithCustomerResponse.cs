using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppServices.Mappers.CustomerBankInfo.Responses
{
    public class GetBankInfoWithCustomerResponse : BaseCustomerBankInfoResponseModel
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerCpf { get; set; }
    }
}
