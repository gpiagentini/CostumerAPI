using System;

namespace DomainServices.Exceptions
{
    public class BankInfoDatabaseValidatorException : Exception
    {
        public BankInfoDatabaseValidatorException(string message) : base(message) { }
    }
}
