using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModels
{
    public class CustomerBase: EntityBase
    {
        public CustomerBase(
            string fullName,
            string email,
            string cpf,
            string cellphone,
            DateTime birthdate,
            bool emailSms,
            bool whatsapp,
            string country,
            string city,
            string postalCode,
            string address,
            int number,
            string emailConfirmation)
        {
            FullName = fullName;
            Email = email;
            Cpf = cpf;
            Cellphone = cellphone;
            Birthdate = birthdate;
            EmailSms = emailSms;
            Whatsapp = whatsapp;
            Country = country;
            City = city;
            PostalCode = postalCode;
            Address = address;
            Number = number;
            EmailConfirmation = emailConfirmation;
        }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Cpf { get; set; }
        public string Cellphone { get; set; }
        public DateTime Birthdate { get; set; }
        public bool EmailSms { get; set; }
        public bool Whatsapp { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Address { get; set; }
        public int Number { get; set; }
        public string EmailConfirmation { get; set; }
    }
}
