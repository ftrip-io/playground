using ftrip.io.framework.auth;
using ftrip.io.framework.Secrets;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ftrip.io.framework_playground.Auth
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly ISecretsManager _secretsManager;

        public AuthController(ISecretsManager secretsManager)
        {
            _secretsManager = secretsManager;
        }

        [HttpGet("auth-get")]
        [Authorize]
        public IActionResult RouteRequiresAuth()
        {
            return Ok();
        }

        [HttpGet("auth-token")]
        public IActionResult GetToken()
        {
            var token = new JwtBuilder()
                .SetSecret(_secretsManager.Get("JWT_SECRET"))
                .SetTime(15)
                .AddClaim(ClaimTypes.Name, "Milos")
                .AddClaim(ClaimTypes.Role, "Rola")
                .Build();

            return Ok(token);
        }
    }
}