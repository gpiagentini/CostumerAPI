using System;

namespace DomainServices.Exceptions
{
    public class CustomerDatabaseValidatorException: Exception
    {
        public CustomerDatabaseValidatorException(string message) : base(message)
        {

        }
    }
}
