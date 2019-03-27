using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Propellerhead.Assignment.MarceloFerraz.Core.Customers.Models;
using Dapper;
using MySql.Data.MySqlClient;
using Propellerhead.Assignment.MarceloFerraz.Core.Commons;

namespace Propellerhead.Assignment.MarceloFerraz.Core.Customers.Data
{
    public class CustomerRepository : BaseRepositoryWithDapper, ICustomerRepository
    {
        private readonly string connectionstring;

        public CustomerRepository(string connectionstring)
        {
            this.connectionstring = connectionstring;
        }

        public Customer Get(int id)
        {
            using (var cnn = new MySqlConnection(connectionstring))
            {
                return cnn.QueryFirst<Customer>(
                    "select id, name, status, contact_details, creation_date from customer where id = @id",
                    new { id });
            }
        }

        public int Create(Customer customer)
        {
            using (var cnn = new MySqlConnection(connectionstring))
            {
                return cnn.ExecuteScalar<int>(
                    "insert into customer (name, status, contact_details) values (@name, @status, @contact_details); select last_insert_id();",
                    new {
                        customer.Name,
                        status = (int) customer.Status,
                        contact_details = customer.ContactDetails
                    });
            }
        }

        public void Update(Customer customer)
        {
            using (var cnn = new MySqlConnection(connectionstring))
            {
                cnn.Execute(
                    "update customer set name = @name, status = @status, contact_details = @contactdetails where id = @id",
                    new
                    {
                        customer.Id,
                        customer.Name,
                        status = (int) customer.Status,
                        contact_details = customer.ContactDetails
                    });
            }
        }
    }
}
