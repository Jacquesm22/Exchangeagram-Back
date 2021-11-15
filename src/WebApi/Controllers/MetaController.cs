using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExchangeAGram.WebApi.Controllers
{
    [Authorize]
    public class MetaController : ApiControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetMetaAction()
        {
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateMetaAction([FromRoute] Guid id)
        {
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteMetaAction([FromRoute] Guid id)
        {
            return Ok();
        }
    }
}
