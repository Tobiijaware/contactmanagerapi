using ContactManagerApiApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactManagerApiApp.Data.Dtos
{
    public class CreateContactsDto
    {

        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public string Email { get; set; }

        public Address Address { get; set; }
    }
}
