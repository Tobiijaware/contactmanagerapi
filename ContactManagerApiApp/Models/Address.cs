using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactManagerApiApp.Models
{
    public class Address
    {
        public string AddressId { get; set; } = Guid.NewGuid().ToString();

        public string Street { get; set; }

        public string City { get; set; }

        public string Country { get; set; }


    }
}
