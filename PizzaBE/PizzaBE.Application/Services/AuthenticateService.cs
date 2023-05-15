using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using PizzaBE.Application.DTOs.ApplicationUser;
using PizzaBE.Application.DTOs.ApplicationUserDTO;
using PizzaBE.Application.Exceptions;
using PizzaBE.Application.Interfaces;
using PizzaBE.Domain.Entities;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PizzaBE.Application.Services
{
    public class AuthenticateService : IAuthenticateService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private SignInManager<ApplicationUser> _signManager;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public AuthenticateService(SignInManager<ApplicationUser> signManager, UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager, IConfiguration configuration, IMapper mapper)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
            _signManager = signManager;
            _mapper = mapper;
        }

        public async Task<ApplicationUserDTO> Register(RegisterDTO model)
        {
            var userExists = await _userManager.FindByEmailAsync(model.Email);
            if (userExists != null)
                throw new UserAlreadyExistsException();

            var user = new CustomerUser()
            {
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.Email,
                title = model.Username,
                orders = new List<Order>()
            };

            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "user");
            }
            else
            {
                throw new UserCreationFailedException();
            }

            return _mapper.Map<ApplicationUserDTO>(user);
        }

        public async Task<IdentityResult> CreateExternalUser(ExternalLoginInfo loginInfo)
        {

            var UserName = loginInfo.Principal.FindFirstValue(ClaimTypes.Name);
            var Email = loginInfo.Principal.FindFirstValue(ClaimTypes.Email);
            // Prepares a new user entity based on the external login data
            ApplicationUser user = new ApplicationUser
            {
                Email = Email,
                SecurityStamp = Guid.NewGuid().ToString(),

                UserName = Email,
                title = UserName

            };


            // Attempts to create the user in the Xperience database
            IdentityResult result = await _userManager.CreateAsync(user);
            if (result.Succeeded)
            {
                // If the user was created successfully, creates a mapping between the user and the given authentication provider
                result = await _userManager.AddLoginAsync(user, loginInfo);
            }

            return result;
        }

        public async Task<JwtTokenResponseDTO> GenerateTokenAsync(LoginDTO model)
        {
            ApplicationUser user = await _userManager.FindByEmailAsync(model.Email);

            if (user != null)
            {
                var result = await _signManager.CheckPasswordSignInAsync(user, model.Password, false);
                if (result.Succeeded)
                {
                    var mappedUser = _mapper.Map<ApplicationUserDTO>(user);
                    var tokenString = GenerateTokenFromUserData(mappedUser);
                    return new JwtTokenResponseDTO
                    {
                        token = tokenString,
                        id = user.Id,
                        email = user.Email,
                        username = user.title,

                    };
                }
            }
            throw new UserNotFoundException();
        }

        public string GenerateTokenFromUserData(ApplicationUserDTO user)
        {

            var claims = new List<Claim> {
                            new Claim (JwtRegisteredClaimNames.GivenName, user.UserName),
                            new Claim (JwtRegisteredClaimNames.Jti, Guid.NewGuid ().ToString ()),
                            new Claim (ClaimTypes.NameIdentifier, user.Id.ToString ()),
                        };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("I-Am-A-Key5244512e79775268374231315e41507e3f6e72734c40397a7b2851674b"));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken("Tokens:Issuer",
                "Tokens:Issuer",
                claims,
                expires: DateTime.Now.AddYears(1),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
