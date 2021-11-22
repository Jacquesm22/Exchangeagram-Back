using ExchangeAGram.Application.Photos.Commands.UploadPhoto;
using ExchangeAGram.Application.Photos.Queries.GetPhotoImage;
using ExchangeAGram.Application.Photos.Queries.GetPhotos;
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
        [HttpPost("upload")]
        public async Task<IActionResult> UploadPhotoAction([FromForm] IFormFile file)
        {
            var command = new UploadPhotoCommand
            {
                FileBytes = GetBytesFromFormFile(file),
                FileName = file.FileName
            };

            await Mediator.Send(command);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetPhotosAction() 
        {
            var photos = await Mediator.Send(new GetPhotosQuery());
            return Ok(photos);
        }

        [HttpGet("user")]
        public async Task<IActionResult> GetUserPhotosAction()
        {
            var photos = await Mediator.Send(new GetPhotosQuery 
            {
                CurrentUser = true
            });
            return Ok(photos);
        }

        [AllowAnonymous]
        [HttpGet("{id}/image")]
        public async Task GetPhotoImageAction([FromRoute] Guid id) 
        {
            var image = await Mediator.Send(new GetPhotoImageQuery 
            {
                PhotoId = id
            });
            await Response.Body.WriteAsync(image, 0, image.Length);
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
