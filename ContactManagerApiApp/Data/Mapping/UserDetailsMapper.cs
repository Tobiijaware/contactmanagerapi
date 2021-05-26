using AutoMapper;
using ContactBook.Lib.Data;
using ContactManagerApiApp.Data.Dtos;
using ContactManagerApiApp.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactManagerApiApp.Data.Mapping
{
    public class UserDetailsMapper : Profile
    {
        public UserDetailsMapper()
        {
            CreateMap<IdentityUser, UserDto>();
        }
    }
}
