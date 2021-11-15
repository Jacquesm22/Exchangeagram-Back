using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ExchangeAGram.WebApi.Controllers
{
    [Authorize]
    public class PhotoController : ApiControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetPhotoAction()
        {
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdatePhotoAction([FromRoute] Guid id)
        {
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePhotoAction([FromRoute] Guid id)
        {
            return Ok();
        }
    }
}
