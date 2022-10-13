namespace DomainModels
{
    public class CustomerBankInfo : EntityBase
    {

        public CustomerBankInfo()
        {
            AccountBalance = 0;
        }

        public decimal AccountBalance { get; set; }
        public int CustomerId { get; }
        public CustomerBase Customer { get; }
    }
}
