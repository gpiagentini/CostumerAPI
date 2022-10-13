using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppServices.Mappers.CustomerBankInfo.Responses
{
    public abstract class BaseCustomerBankInfoResponseModel
    {
        public decimal AccountBallance { get; set; }
    }
}
