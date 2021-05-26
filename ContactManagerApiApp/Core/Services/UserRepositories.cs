using ContactManagerApiApp.Core.Abstractions;
using ContactManagerApiApp.Data;
using ContactManagerApiApp.Data.Dtos;
using ContactManagerApiApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactManagerApiApp.Core.Repositories
{
    public class UserRepositories : IUserRepo
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public UserRepositories(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<IEnumerable<IdentityUser>> GetUserByEmailAsync(string email)
        {
            var userByEmail = await _applicationDbContext.Users.Where(x => x.Email == email).ToListAsync();
            return userByEmail;
        }

        public async Task<IEnumerable<IdentityUser>> GetUserByIdAsync(string Id)
        {
            var userById = await _applicationDbContext.Users.Where(x => x.Id == Id).ToListAsync();
            return userById;
        }

        public async Task<IEnumerable<IdentityUser>> GetAllUsersAsync()
        {
            var allUsers = await _applicationDbContext.Users.ToListAsync();
            return allUsers;
        }

        public async Task<bool> CreateAsyncUser(CreateContactsDto contacts)
        {
            Contacts saveContacts = new Contacts()
            {
                Firstname = contacts.Firstname,
                Lastname = contacts.Lastname,
                Email = contacts.Email,
                Address = contacts.Address
            };

            var result = await _applicationDbContext.Contacts.AddAsync(saveContacts);
            return true;

        }
    }
}
