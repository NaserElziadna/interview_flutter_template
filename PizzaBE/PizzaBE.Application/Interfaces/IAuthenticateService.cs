using Microsoft.AspNetCore.Identity;
using PizzaBE.Application.DTOs.ApplicationUser;
using PizzaBE.Application.DTOs.ApplicationUserDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaBE.Application.Interfaces
{
    public interface IAuthenticateService
    {
        Task<ApplicationUserDTO> Register(RegisterDTO model);
        Task<IdentityResult> CreateExternalUser(ExternalLoginInfo loginInfo);
        Task<JwtTokenResponseDTO> GenerateTokenAsync(LoginDTO model);
        string GenerateTokenFromUserData(ApplicationUserDTO user);
    }
}
