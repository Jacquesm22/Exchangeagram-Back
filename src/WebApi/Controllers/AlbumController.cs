using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExchangeAGram.WebApi.Controllers
{
    [Authorize]
    public class AlbumController : ApiControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAlbumAction()
        {
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateAlbumAction([FromRoute] Guid id)
        {
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAlbumAction([FromRoute] Guid id)
        {
            return Ok();
        }
    }
}
