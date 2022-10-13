using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppServices.Mappers.CustomerBankInfo.Requests
{
    public class UpdateCustomerBankInfoRequest
    {
        public AccountRequestType RequestType { get; set; }
        public decimal Value { get; set; }
    }

    public enum AccountRequestType
    {
        [Description("Depositar")]
        Deposit = 1,
        [Description("Sacar")]
        Withdraw = 2
    }
}
