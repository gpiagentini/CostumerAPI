using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainServices.Exceptions
{
    public class PortfolioDatabaseValidationException : Exception
    {
        public PortfolioDatabaseValidationException(string message) : base(message)
        {

        }
    }
}
