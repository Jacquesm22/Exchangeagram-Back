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
        [HttpGet]
        public async Task<IActionResult> GetUserAction()
        {
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateUserAction([FromRoute] Guid id)
        {
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUserAction([FromRoute] Guid id)
        {
            return Ok();
        }
    }
}
