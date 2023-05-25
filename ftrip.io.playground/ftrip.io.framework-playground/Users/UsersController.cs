using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Threading.Tasks;

namespace ftrip.io.framework_playground.Users
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly UsersHttpClient _httpClient;

        public UsersController(UsersHttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [HttpGet]
        public async Task<IActionResult> ReadUser()
        {
            Activity.Current.AddTag("Milos", "Test");

            return Ok(await _httpClient.GetUsers());
        }
    }
}