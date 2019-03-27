using Microsoft.AspNetCore.Mvc;
using PassOn;
using Propellerhead.Assignment.MarceloFerraz.Core.Customers.Data;
using Propellerhead.Assignment.MarceloFerraz.Core.Notes;
using Propellerhead.Assignment.MarceloFerraz.Core.Notes.Data;
using Propellerhead.Assignment.MarceloFerraz.Web.Areas.Customers.Models;
using Propellerhead.Assignment.MarceloFerraz.Web.Areas.Notes.Models;
using Propellerhead.Assignment.MarceloFerraz.Web.Commons;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Propellerhead.Assignment.MarceloFerraz.Web.Areas.Notes.Controllers
{
    using BusinessNote = Core.Notes.Models.Note;

    [Route("api/notes")]
    public class NotesController : Controller
    {
        private readonly INotesService noteService;
        private readonly INotesRepository noteRepository;
        private readonly ICustomerRepository customerRepository;
        
        public NotesController(
            INotesService noteService,
            INotesRepository noteRepository,
            ICustomerRepository customerRepository)
        {
            this.noteService = noteService;
            this.noteRepository = noteRepository;
            this.customerRepository = customerRepository;
        }

        // GET api/customers/5
        [HttpGet("{id}")]
        public Customer Get(int id)
        {
            return noteRepository
                .Get(id)
                .To<Customer>();
        }

        // POST api/customers
        [HttpPost]
        public NewIdResponse Post([FromBody] Note model)
        {
            var id = noteService.Create(
                model.To<BusinessNote>());

            return new NewIdResponse(id);
        }

        // PUT api/customers/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Note model)
        {
            var note = 
                new BusinessNote(customerRepository)
                {
                    Id = id
                };

            Pass.Onto(model, note);

            noteService.Update(note);
        }
    }
}
