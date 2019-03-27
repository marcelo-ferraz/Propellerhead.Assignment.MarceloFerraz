using Propellerhead.Assignment.MarceloFerraz.Web.Areas.Customers.Models;
using System;
using System.Collections.Generic;

namespace Propellerhead.Assignment.MarceloFerraz.Web.Areas.Search.Models
{
    [Serializable]
    public class CustomerSearchModel
    {
        public int Id { get; set; }
        
        public string Status { get; set; }

        public string Name { get; set; }

        public string ContactDetails { get; set; }

        public NoteSearchModel[] Notes { get; set; }
    }
}
