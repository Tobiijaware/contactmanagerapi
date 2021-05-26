using AutoMapper;
using ContactManagerApiApp.Core.Abstractions;
using ContactManagerApiApp.Data.Dtos;
using ContactManagerApiApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactManagerApiApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepo _userRepository;
        private readonly IMapper _mapper;

        public UserController(IUserRepo userService, IMapper mapper)
        {
            _userRepository = userService;
            _mapper = mapper;
        }

        [HttpGet("all-users")]
        public async Task<IActionResult> GetAllUsersAsync()
        {
            var allUsers = await _userRepository.GetAllUsersAsync();
            var resources = _mapper.Map<IEnumerable<IdentityUser>, IEnumerable<UserDto>>(allUsers);
            return Ok(resources);
        }

        [HttpGet("user/email")]
        public async Task<IActionResult> GetUserByIdAsync(string Id)
        {
            var user = await _userRepository.GetUserByIdAsync(Id);
            return Ok(user);
        }

        [HttpGet("user/add-new")]
        public async Task<IActionResult> Add([FromBody] CreateContactsDto model)
        {
            var user = await _userRepository.CreateAsyncUser(model);
            if (user)
            {
                return Ok(user);
            }
            return BadRequest();
            
        }

    }
}
