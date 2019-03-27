using Propellerhead.Assignment.MarceloFerraz.Core.Commons;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Propellerhead.Assignment.MarceloFerraz.Core.Customers.Models
{
    public class Customer
    {
        public const string InvalidIdMessage = "The customer id have to be a natural number bigger than zero";
        public const string InvalidStatusMessage = "The customer is required to have a valid status";
        public const string NullOrEmptyNameMessage = "The customer has to have a name";

        public int? Id { get; set; }
        
        public CustomerStatus Status { get; set; }

        public string Name { get; set; }

        public string ContactDetails { get; set; }

        public void Validate()
        {
            if (Id.HasValue && this.Id.Value < 0)
            { throw new BusinessException(InvalidIdMessage); }

            if(this.Status == CustomerStatus.None)
            { throw new BusinessException(InvalidStatusMessage); }

            if(string.IsNullOrEmpty(Name))
            { throw new BusinessException(NullOrEmptyNameMessage); }
        }
    }
}
