using Propellerhead.Assignment.MarceloFerraz.Core.Customers.Data;
using Propellerhead.Assignment.MarceloFerraz.Core.Customers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Propellerhead.Assignment.MarceloFerraz.Core.Customers
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository customerRepository;

        public CustomerService(ICustomerRepository repository)
        {
            this.customerRepository = repository;
        }

        public int Create(Customer customer)
        {
            customer.Validate();

            return customerRepository.Create(customer);
        }

        public void Update(Customer customer)
        {
            customer.Validate();

            customerRepository.Update(customer);
        }
    }
}
