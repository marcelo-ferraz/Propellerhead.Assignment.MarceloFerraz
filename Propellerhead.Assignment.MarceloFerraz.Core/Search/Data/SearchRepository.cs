using MySql.Data.MySqlClient;
using Propellerhead.Assignment.MarceloFerraz.Core.Search.Models;
using System.Linq;
using System.Collections.Generic;
using Dapper;
using Propellerhead.Assignment.MarceloFerraz.Core.Customers.Models;
using Propellerhead.Assignment.MarceloFerraz.Core.Search.Model;
using Propellerhead.Assignment.MarceloFerraz.Core.Commons;

namespace Propellerhead.Assignment.MarceloFerraz.Core.Search
{
    public class SearchRepository : BaseRepositoryWithDapper, ISearchRepository
    {
        private readonly string connectionstring;

        public SearchRepository(string connectionstring)
        {
            this.connectionstring = connectionstring;
        }

        public CustomerSearchModel Get(int id)
        {
            using (var cnn = new MySqlConnection(connectionstring))
            {
                var customer = cnn.QueryFirst<CustomerSearchModel>(
                    "select id, name, status, contact_details from customer where id = @id",
                    new { id });

                customer.Notes = cnn
                    .Query<NoteSearchModel>("select c.id consumer_id, n.id, n.content from note n inner join customer c on n.customer_id = c.id where c.id = @id", new { id })
                    .ToArray();

                return customer;
            }
        }

        public IList<CustomerSearchModel> Search(string term)
        {
            Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
            using (var cnn = new MySqlConnection(connectionstring))
            {
                var customers = cnn
                    .Query<CustomerSearchModel>("select Id, Name, Status, Contact_details from Customer where name like CONCAT('%', @term, '%')", new { term });

                var notes = cnn.Query<NoteSearchModel>(
                    "select c.id customer_id, n.id, n.content from note n inner join customer c on n.customer_id = c.id where c.name like CONCAT('%', @term, '%')",
                    new { term });

                return customers
                    .Select(c => AddNotes(c, notes))
                    .ToList();
            }
        }

        protected CustomerSearchModel AddNotes(CustomerSearchModel customer, IEnumerable<NoteSearchModel> notes)
        {
            customer.Notes = notes
                .Where(n => n.CustomerId == customer.Id)
                .ToArray();
            return customer;
        }
    }
}
