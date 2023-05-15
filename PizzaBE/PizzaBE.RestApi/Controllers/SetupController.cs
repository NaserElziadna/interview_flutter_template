using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzaBE.Application.Interfaces;
using System.Threading.Tasks;

namespace PizzaBE.RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SetupController : ControllerBase
    {
        private readonly ISetupService _setupService;
        public SetupController(ISetupService setupService)
        {
            _setupService = setupService;
        }

        [HttpGet]
        [Route("seed")]
        public async Task<IActionResult> SeedData()
        {
            try
            {
                await _setupService.CreateWorkerLoginAndRolesAsync();

                return Ok();
            }
            catch (System.Exception ex)
            {

                throw;
            }
        }
    }
}
