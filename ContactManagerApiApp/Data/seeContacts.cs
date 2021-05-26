using ContactManagerApiApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactManagerApiApp.Data
{
    public class seeContacts
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public seeContacts(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;

        }

        public void SaveContacts()
        {
            Contacts saveContacts1 = new Contacts()
            {
                Id = Guid.NewGuid().ToString(),
                Firstname = "Ahmed",
                Lastname = "Dauda",
                Email = "ahmeddauda@gmail.com",
                Address = new Address()
                {
                    AddressId = Guid.NewGuid().ToString(),
                    City = "Lagos",
                    Street = "Asajon Way",
                    Country = "Nigeria"
                }

            };
            Contacts saveContacts2 = new Contacts()
            {
                Id = Guid.NewGuid().ToString(),
                Firstname = "Chidi",
                Lastname = "Michael",
                Email = "chidimichael@gmail.com",
                Address = new Address()
                {
                    AddressId = Guid.NewGuid().ToString(),
                    City = "Lagos",
                    Street = "Asajon Way",
                    Country = "Nigeria"
                }

            };
            Contacts saveContacts3 = new Contacts()
            {
                Id = Guid.NewGuid().ToString(),
                Firstname = "Joshua",
                Lastname = "Gbogodor",
                Email = "joshuagbodor@gmail.com",
                Address = new Address()
                {
                    AddressId = Guid.NewGuid().ToString(),
                    City = "Lagos",
                    Street = "Asajon Way",
                    Country = "Nigeria"
                }

            };
            _applicationDbContext.Contacts.Add(saveContacts1);
            _applicationDbContext.Contacts.Add(saveContacts2);
            _applicationDbContext.Contacts.Add(saveContacts3);
        }
    }
}
