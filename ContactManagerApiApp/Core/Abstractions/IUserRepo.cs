using ContactManagerApiApp.Data.Dtos;
using ContactManagerApiApp.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactManagerApiApp.Core.Abstractions
{
    public interface IUserRepo
    {
        Task<IEnumerable<IdentityUser>> GetAllUsersAsync();

        Task<IEnumerable<IdentityUser>> GetUserByEmailAsync(string email);

        Task<IEnumerable<IdentityUser>> GetUserByIdAsync(string Id);

        Task<bool> CreateAsyncUser(CreateContactsDto model);
    }
}
