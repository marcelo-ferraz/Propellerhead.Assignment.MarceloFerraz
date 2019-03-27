using Propellerhead.Assignment.MarceloFerraz.Core.Notes.Data;
using Propellerhead.Assignment.MarceloFerraz.Core.Notes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Propellerhead.Assignment.MarceloFerraz.Core.Notes
{
    public class NotesService : INotesService
    {
        private readonly INotesRepository customerRepository;

        public NotesService(INotesRepository repository)
        {
            this.customerRepository = repository;
        }

        public int Create(Note note)
        {
            note.Validate();

            return customerRepository.Create(note);
        }

        public void Update(Note customer)
        {
            customer.Validate();

            customerRepository.Update(customer);
        }
    }
}
