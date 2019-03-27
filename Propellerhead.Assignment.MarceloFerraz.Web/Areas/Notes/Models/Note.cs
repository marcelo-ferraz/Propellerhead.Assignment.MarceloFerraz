using System;
using System.ComponentModel.DataAnnotations;

namespace Propellerhead.Assignment.MarceloFerraz.Web.Areas.Notes.Models
{
    [Serializable]
    public class Note
    {
        public int? Id { get; set; }

        [Required]
        public int ConsumerId { get; set; }

        [Required]
        public string Content { get; set; }

        public DateTime CreationDate { get; set; }
    }
}
