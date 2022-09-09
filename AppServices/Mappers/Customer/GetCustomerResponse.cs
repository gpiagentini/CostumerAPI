using System;

namespace AppServices.Mappers.Customer
{
    public class GetCustomerResponse
    {
        public GetCustomerResponse(
            string fullName,
            string email,
            string cpf,
            string cellphone,
            DateTime birthdate,
            string country,
            string city,
            string address,
            int number)
        {
            FullName = fullName;
            Email = email;
            Cpf = cpf;
            Cellphone = cellphone;
            Birthdate = birthdate;
            Country = country;
            City = city;
            Address = address;
            Number = number;
        }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Cpf { get; set; }
        public string Cellphone { get; set; }
        public DateTime Birthdate { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public int Number { get; set; }
    }
}
