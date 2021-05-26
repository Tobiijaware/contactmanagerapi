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

namespace ContactManagerApiApp.Core.Services
{
    public class AuthRepository : IAuthRepo
    {
        //private readonly ApplicationDbContext _applicationDbContext;

        //private readonly UserManager<Users> _userManager;

        //public SignInManager<Users> _signManager { get; }
       
        //public AuthRepository(UserManager<Users> userManager,
        //   SignInManager<Users> signInManager)
        //{
        //    _userManager = userManager;
        //    _signManager = signInManager;
            
        //}
        //public async Task<Users> Login(LoginDto model)
        //{
        //    var user = await _userManager.FindByEmailAsync(model.Email);
        //    if (user == null)
        //        return user;

        //    var result = await _signManager.PasswordSignInAsync(user, model.Password,
        //       isPersistent: model.RememberMe, true); // account lockedout is set




        //}
    }
}
