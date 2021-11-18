using ExchangeAGram.Application.Common.Interfaces;
using ExchangeAGram.Application.Common.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ExchangeAGram.WebApi.Controllers
{
    [Authorize]
    public class AuthController : ApiControllerBase
    {
        private readonly IIdentityService _identityService;

        public AuthController(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> AuthenticateUserAction([FromBody] AuthenticateUserModel model)
        {
            if (!ValidateAuthenticateMobileUserModel(model))
            {
                return BadRequest("invalid model");
            }

            var result = await _identityService.AuthenticateUserAsync(model.Username, model.Password);

            return Ok(result);
        }

        private static bool ValidateAuthenticateMobileUserModel(AuthenticateUserModel model)
        {
            if (model == null)
            {
                return false;
            }

            if (string.IsNullOrWhiteSpace(model.Username))
            {
                return false;
            }

            if (string.IsNullOrWhiteSpace(model.Password))
            {
                return false;
            }

            return true;
        }
    }
}
