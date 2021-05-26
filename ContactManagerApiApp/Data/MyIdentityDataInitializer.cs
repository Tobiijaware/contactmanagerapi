using ContactManagerApiApp.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactManagerApiApp.Data
{
    public class MyIdentityDataInitializer
    {
       
        public static void SeedData
        (UserManager<IdentityUser> userManager,
        RoleManager<IdentityRole> roleManager)
        {
            SeedRoles(roleManager);
            SeedUsers(userManager);


            
        }

        public static void SeedUsers
        (UserManager<IdentityUser> userManager)
        {
            if (userManager.FindByNameAsync
            ("user1").Result == null)
            {
                IdentityUser user = new IdentityUser();
                user.Id = Guid.NewGuid().ToString();
                user.UserName = "Lee";
                user.Email = "lee@gmail.com";
                user.PhoneNumber = "07037796307";
                var password = "Boondocks1!";
                

                IdentityResult result = userManager.CreateAsync
                (user, password).Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user,
                                        "User").Wait();
                }
            }


            if (userManager.FindByNameAsync
        ("user2").Result == null)
            {
                IdentityUser user = new IdentityUser();
                user.UserName = "Tobi";
                user.Email = "tobi@gmail.com";
                user.PhoneNumber = "07037796309";
                var password = "Boondocks1!";

                IdentityResult result = userManager.CreateAsync
                (user, password).Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user,
                                        "Admin").Wait();
                }
            }
        }

        public static void SeedRoles
        (RoleManager<IdentityRole> roleManager)
        {
            if (!roleManager.RoleExistsAsync
            ("User").Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = "User";
                role.Id = Guid.NewGuid().ToString();
                IdentityResult roleResult = roleManager.
                CreateAsync(role).Result;
            }


            if (!roleManager.RoleExistsAsync
            ("Admin").Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = "Admin";
                role.Id = Guid.NewGuid().ToString();
                IdentityResult roleResult = roleManager.
                CreateAsync(role).Result;
            }

        }


       
    }
}
