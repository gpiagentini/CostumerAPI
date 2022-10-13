using System;

namespace DomainServices.Exceptions
{
    public class ProductDatabaseValidationException : Exception
    {
        public ProductDatabaseValidationException(string message) : base(message)
        {

        }
    }
}
