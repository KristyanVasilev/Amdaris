namespace BookShop.Presentantion.Controllers
{
    using BookShop.Application.Images.DTOs;
    using BookShop.Application.Images.UploadImages;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class FilesController : BaseController<FilesController>
    {

        [HttpPost("Images")]
        public async Task<IActionResult> UploadImages(IList<IFormFile> formFiles)
        {
            var uploadImagesCommand = new UploadImagesCommand();

            foreach (var formFile in formFiles)
            {
                var file = new FileDto
                {
                    Content = formFile.OpenReadStream(),
                    Name = formFile.FileName,
                    ContentType = formFile.ContentType                   
                };
                uploadImagesCommand.Files.Add(file);
            }

            var response = await Mediator.Send(uploadImagesCommand);

            return Ok(response);
        }
    }
}
