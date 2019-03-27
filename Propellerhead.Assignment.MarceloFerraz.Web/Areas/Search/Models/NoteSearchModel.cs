using System;
using System.ComponentModel.DataAnnotations;

namespace Propellerhead.Assignment.MarceloFerraz.Web.Areas.Search.Models
{
    [Serializable]
    public class NoteSearchModel
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public DateTime CreationDate { get; set; }
    }
}
