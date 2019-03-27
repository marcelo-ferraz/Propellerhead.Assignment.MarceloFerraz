using Propellerhead.Assignment.MarceloFerraz.Core.Customers.Models;
using System.Threading.Tasks;

namespace Propellerhead.Assignment.MarceloFerraz.Core.Customers
{
    public interface ICustomerService
    {
        int Create(Customer customer);
        void Update(Customer customer);
    }
}