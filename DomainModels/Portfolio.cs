using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModels
{
    public class Portfolio : EntityBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal TotalBalance { get; set; }
        public int CustomerId { get; }
        public CustomerBase Customer { get; }
    }
}
