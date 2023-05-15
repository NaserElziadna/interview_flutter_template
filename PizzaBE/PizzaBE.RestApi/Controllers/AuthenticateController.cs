using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzaBE.RestApi.Models;
using System.Threading.Tasks;
using System;
using PizzaBE.Application.Interfaces;
using PizzaBE.Application.DTOs.ApplicationUser;

namespace PizzaBE.RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private readonly IAuthenticateService _authontication;
        public AuthenticateController(IAuthenticateService authontication)
        {
            _authontication = authontication;
        }

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<MyCustomApiResponse<object>>> Login([FromBody] LoginDTO model)
        {
            try
            {
                var token = await _authontication.GenerateTokenAsync(model);
                return new MyCustomApiResponse<object>(token);
            }
            catch (Exception ex)
            {
                return Unauthorized(ex.ToString());
            }
        }

        [HttpPost]
        [Route("register")]
        public async Task<ActionResult<MyCustomApiResponse<object>>> Register([FromBody] RegisterDTO model)
        {
            try
            {
                await _authontication.Register(model);
            }
            catch (Exception ex)
            {
                throw;
            }
            return Ok(new { Status = "Success", Message = "User created successfully!" });
        }
    }
}
