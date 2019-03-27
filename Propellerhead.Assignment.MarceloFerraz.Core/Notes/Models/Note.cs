using Propellerhead.Assignment.MarceloFerraz.Core.Commons;
using Propellerhead.Assignment.MarceloFerraz.Core.Customers.Data;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Propellerhead.Assignment.MarceloFerraz.Core.Notes.Models
{
    public class Note
    {
        public const string InvalidIdMessage = "The note id have to be a natural number bigger than zero";
        public const string CustomerNotFoundMessage = "The customer for this customer has to exist";

        ICustomerRepository customerRepository;

        public Note(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        public int? Id { get; set; }

        public int CustomerId { get; set; }

        public string Content { get; set; }

        public DateTime? CreationDate { get; set; }

        public void Validate()
        {
            if (Id.HasValue && this.Id.Value < 0)
            { throw new BusinessException(InvalidIdMessage); }

            var customer = 
                customerRepository.Get(CustomerId);

            if (customer == null)
            { throw new BusinessException(CustomerNotFoundMessage); }
        }
    }
}
