namespace BookShop.Presentantion.Controllers
{
    using BookShop.Application.Images.DTOs;
    using BookShop.Application.Images.UploadImages;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Identity.Web.Resource;


    [RequiredScope(RequiredScopesConfigurationKey = "AzureAd:Scopes")]
    [Authorize(AuthenticationSchemes = "Bearer", Roles = "Manager")]
    [ApiController]
    [Route("api/[controller]")]
    public class FilesController : BaseController<FilesController>
    {
        [HttpPost("Images")]
        public async Task<IActionResult> UploadImages(IFormFile file)
        {

            Logger.LogInformation(message: $"Request recieved by Controller: {nameof(FilesController)}, Action: {nameof(UploadImages)}, DateTime: {DateTime.Now}");

            var uploadImagesCommand = new UploadImagesCommand();


            var file1 = new FileDto
            {
                Content = file.OpenReadStream(),
                Name = file.FileName,
                ContentType = file.ContentType
            };
            uploadImagesCommand.Files.Add(file1);


            var response = await Mediator.Send(uploadImagesCommand);

            return Ok(response);
        }
    }
}
