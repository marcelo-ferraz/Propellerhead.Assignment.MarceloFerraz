using Propellerhead.Assignment.MarceloFerraz.Core.Commons;
using System;
using System.ComponentModel.DataAnnotations;

namespace Propellerhead.Assignment.MarceloFerraz.Web.Areas.Customers.Models
{
    [Serializable]
    public class Customer
    {
        public int? Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "The status is required")]
        public CustomerStatus Status { get; set; }

        [Required(AllowEmptyStrings =false, ErrorMessage = "Name is required")]
        public string Name { get; set; }

        public string ContactDetails { get; set; }
    }
}
