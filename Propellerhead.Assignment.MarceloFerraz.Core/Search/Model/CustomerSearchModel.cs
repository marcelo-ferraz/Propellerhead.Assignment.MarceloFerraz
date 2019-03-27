using Propellerhead.Assignment.MarceloFerraz.Core.Commons;
using Propellerhead.Assignment.MarceloFerraz.Core.Search.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Propellerhead.Assignment.MarceloFerraz.Core.Search.Models
{
    public class CustomerSearchModel
    {
        public int Id { get; set; }
        
        public byte Status { get; set; }

        public string Name { get; set; }

        public string ContactDetails { get; set; }

        public NoteSearchModel[] Notes { get; set; }
    }
}
