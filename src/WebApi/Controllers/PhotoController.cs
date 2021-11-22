using ExchangeAGram.Application.Photos.Commands.UploadPhoto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Threading.Tasks;

namespace ExchangeAGram.WebApi.Controllers
{
    [Authorize]
    public class PhotoController : ApiControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> GetPhotoAction([FromForm] IFormFile file)
        {
            var command = new UploadPhotoCommand
            {
                FileBytes = GetBytesFromFormFile(file),
                FileName = file.FileName
            };

            var result = await Mediator.Send(command);
            return Ok(result);
        }

        private static byte[] GetBytesFromFormFile(IFormFile formFile)
        {
            if (formFile == null)
            {
                throw new ArgumentNullException(nameof(formFile));
            }

            if (formFile.Length == 0)
            {
                return Array.Empty<byte>();
            }

            using var ms = new MemoryStream();
            formFile.CopyTo(ms);
            var fileBytes = ms.ToArray();
            return fileBytes;
        }
    }
}
