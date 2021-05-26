using ContactManagerApiApp.Data;
using ContactManagerApiApp.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactBook.Lib.Data
{
    public static class Seed
    {
        private const string password = "Password1!";

        public static void EnsurePopulated(IApplicationBuilder app)
        {
            var context = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<ApplicationDbContext>();

            if(context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }
            if (context.Users.Any())
            {
                return;
            }
            else
            {
                var userManager = app.ApplicationServices.CreateScope()
                                              .ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();

                var user = new IdentityUser
                {
                    UserName = "lee@gmail.com",
                    Email = "lee@gmail.com",
                    PhoneNumber = "08137758674"
                    
                };

                userManager.CreateAsync(user, password).GetAwaiter().GetResult();
            }
            
        }
    }
}
