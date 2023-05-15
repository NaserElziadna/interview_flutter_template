using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using PizzaBE.Application.DTOs.ApplicationUserDTO;
using PizzaBE.Application.Interfaces;
using PizzaBE.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaBE.Application.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private SignInManager<ApplicationUser> _signManager;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserService(IHttpContextAccessor httpContextAccessor, SignInManager<ApplicationUser> signManager, UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager, IConfiguration configuration, IMapper mapper)
        {
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
            _signManager = signManager;
            _mapper = mapper;
        }
        public async Task<ApplicationUser> GetCurrenLoggedInUserAsync()
        {
            var user = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);
            var userDTO = _mapper.Map<ApplicationUser>(user);
            return userDTO;
        }
    }
}
