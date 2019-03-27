using System;
using System.Collections.Generic;
using System.Text;

namespace Propellerhead.Assignment.MarceloFerraz.Core.Search.Model
{
    public class NoteSearchModel
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }

        public string Content { get; set; }

        public DateTime CreationDate { get; set; }
    }
}
