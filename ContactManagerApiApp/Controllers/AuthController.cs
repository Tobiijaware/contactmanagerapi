using ContactManagerApiApp.Core.Abstractions;
using ContactManagerApiApp.Data.Dtos;
using ContactManagerApiApp.Models;
using ContactManagerApiApp.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactManagerApiApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
       

        private readonly UserManager<IdentityUser> _userManager;

        public SignInManager<IdentityUser> _signManager { get; }
        private readonly IConfiguration _config;

       
        public AuthController(UserManager<IdentityUser> userManager,
           SignInManager<IdentityUser> signInManager, IConfiguration config)
        {
            _userManager = userManager;
            _signManager = signInManager;
            _config = config;

        }


        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginDto model)
        {
            
            var user = await _userManager.FindByEmailAsync(model.Email);
            //var roles = await _userManager.GetRolesAsync(user);

            if (user == null)
                return BadRequest(new { message="User Does Not exist" });

            var result = await _signManager.PasswordSignInAsync(user, model.Password,
               isPersistent: model.RememberMe, false); // account lockedout is set

            if (!result.Succeeded)
            {
                return BadRequest(new { message = "Invalid Credentials" });
            }
            var token = Token.GenerateToken(user.UserName, user.Id, user.Email, _config);

            //store in cookie
            Response.Cookies.Append("jwt", token, new CookieOptions
            {
                HttpOnly = true
            });

            return Ok(new {
                token 
            });

        }

       [HttpGet("user")]
       public IActionResult AuthUser()
       {
            try
            {
                var tokenCookie = Request.Cookies["jwt"];
                var token = Token.Verify(tokenCookie, _config);
                var Id = token.Issuer;
                var user =  _userManager.FindByIdAsync(Id);
                return Ok(user);
            }
            catch (Exception e)
            {
                return Unauthorized(e);
            }
           
        }
    }
}
 