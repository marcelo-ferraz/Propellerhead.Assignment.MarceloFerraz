using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Propellerhead.Assignment.MarceloFerraz.Core.Customers.Models;
using Dapper;
using MySql.Data.MySqlClient;
using Propellerhead.Assignment.MarceloFerraz.Core.Commons;
using Propellerhead.Assignment.MarceloFerraz.Core.Notes.Models;

namespace Propellerhead.Assignment.MarceloFerraz.Core.Notes.Data
{
    public class NotesRepository : BaseRepositoryWithDapper, INotesRepository
    {
        private readonly string connectionstring;

        public NotesRepository(string connectionstring)
        {
            this.connectionstring = connectionstring;
        }

        public Note Get(int id)
        {
            using (var cnn = new MySqlConnection(connectionstring))
            {
                return cnn.QueryFirst<Note>(
                    "select customer_id, id, creation_date, content from note  where id = @id",
                    new { id });
            }
        }

        public int Create(Note note)
        {
            using (var cnn = new MySqlConnection(connectionstring))
            {
                return cnn.ExecuteScalar<int>(
                    "insert into note (customer_id, creation_date, content) values (@customer_id, @creation_date, @content); select last_insert_id();",
                    new {
                        note.Content,
                        note.CustomerId,
                        creation_date = note.CreationDate ?? DateTime.Now
                    });
            }
        }

        public void Update(Note note)
        {
            using (var cnn = new MySqlConnection(connectionstring))
            {
                cnn.Execute(
                    "update note set customer_id = @customer_id, creation_date = @creation_date, content = @content where id = @id",
                    new
                    {
                        note.Id,
                        note.Content,
                        note.CustomerId,
                        creation_date = note.CreationDate ?? DateTime.Now
                    });
            }
        }
    }
}
