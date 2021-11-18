using ExchangeAGram.Application.Users.Commands.CreateUser;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExchangeAGram.WebApi.Controllers
{
    [Authorize]
    public class UserController : ApiControllerBase
    {
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> CreateUserAction(CreateUserCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }
    }
}
