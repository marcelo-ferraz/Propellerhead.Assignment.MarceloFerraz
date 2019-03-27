using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Propellerhead.Assignment.MarceloFerraz.Core.Customers.Models;

namespace Propellerhead.Assignment.MarceloFerraz.Core.Customers.Data
{
    public interface ICustomerRepository
    {
        Customer Get(int id);
        int Create(Customer customer);
        void Update(Customer customer);
    }
}
