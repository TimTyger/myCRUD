using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CorpersMVC.Models
{
    public class Corpers
    {
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public string School { get; set; }

        [Required]
        public string Discipline { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        public string StateCode { get; set; }
    }
}