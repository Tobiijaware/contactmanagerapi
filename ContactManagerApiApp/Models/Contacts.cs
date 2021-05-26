using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ContactManagerApiApp.Models
{
    public class Contacts
    {
        

        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        public string Firstname { get; set; }

        [Required]
        public string Lastname { get; set; }

        public string Email { get; set; }

        public Address Address { get; set; }

        //public string Photo { get; set; }
    }
}
