using System;

namespace AppServices.Mappers.Customer.Responses
{
    public class GetCustomerResponse
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Cpf { get; set; }
        public string Cellphone { get; set; }
        public DateTime Birthdate { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public int Number { get; set; }
        public decimal AccountBalance { get; set; }
    }
}
