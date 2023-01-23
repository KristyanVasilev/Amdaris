namespace BookShop.Presentantion.Controllers
{
    using BookShop.Application.Publications.Commands.CreatePublication;
    using BookShop.Application.Publications.Commands.DeletePublication;
    using BookShop.Application.Publications.Commands.UnDeletePublication;
    using BookShop.Application.Publications.Commands.UpdatePublication;
    using BookShop.Application.Publications.Queries.GetPublication;
    using BookShop.Application.Publications.Queries.GetPublicationByAuthor;
    using BookShop.Application.Publications.Queries.GetPublicationByGenre;
    using BookShop.Application.Publications.Queries.GetPublicationById;
    using BookShop.Application.Publications.Queries.GetPublicationByName;
    using BookShop.Application.Publications.Queries.GetPublicationsByKeyWord;
    using BookShop.Presentantion.DTOs;
    using BookShop.Presentantion.Filters;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Identity.Web.Resource;

    [RequiredScope(RequiredScopesConfigurationKey = "AzureAd:Scopes")]
    [Authorize(AuthenticationSchemes = "Bearer")]
    [Route("api/[controller]")]
    [ApiController]
    public class PublicationController : BaseController<PublicationController>
    {
        [HttpPost]
        [Route("create")]
        [ValidateModel]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Manager")]
        public async Task<IActionResult> CreatePublication([FromBody] PublicationPostDto publication)
        {
            Logger.LogInformation(message: $"Request recieved by Controller: {nameof(PublicationController)}, Action: {nameof(CreatePublication)}, DateTime: {DateTime.Now}");
            var command = Mapper.Map<CreatePublicationCommand>(publication);

            var result = await Mediator.Send(command);
            return Created("/publication", result);
        }

        [HttpPost]
        [Route("unDelete")]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Manager")]
        public async Task<IActionResult> UnDeletePublication(string publicationName)
        {
            var command = new UnDeletePublicationCommand(publicationName);

            var result = await Mediator.Send(command);
            var mappedResult = Mapper.Map<PublicationGetDto>(result);
            return Ok(mappedResult);
        }

        [HttpPost("update/{id}")]
        [ValidateModel]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Manager")]
        public async Task<IActionResult> UpdatePublication([FromBody] PublicationPutDto publication, int id)
        {
            publication.Id = id;
            var command = Mapper.Map<UpdatePublicationCommand>(publication);

            var result = await Mediator.Send(command);
            return Ok(result);
        }

        [HttpGet]
        [Route("all")]
        [AllowAnonymous]
        public async Task<IActionResult> GetPublications()
        {
            var command = new GetPublicationsQuery();

            var result = await Mediator.Send(command);
            var mappedResult = Mapper.Map<IEnumerable<PublicationGetDto>>(result);
            return Ok(mappedResult);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var command = new GetPublicationByIdQuery(id);

            var result = await Mediator.Send(command);
            var mappedResult = Mapper.Map<PublicationGetDto>(result);
            return Ok(mappedResult);
        }

        [HttpGet]
        [Route("getByAuthor")]
        [AllowAnonymous]
        public async Task<IActionResult> GetPublicationByAuthor(string authorName)
        {
            var command = new GetPublicationByAuthorQuery(authorName);

            var result = await Mediator.Send(command);
            var mappedResult = Mapper.Map<IEnumerable<PublicationGetDto>>(result);
            return Ok(mappedResult);
        }

        [HttpGet]
        [Route("getByGenre")]
        [AllowAnonymous]
        public async Task<IActionResult> GetPublicationByGenre(string genreName)
        {
            var command = new GetPublicationByGenreQuery(genreName);

            var result = await Mediator.Send(command);
            var mappedResult = Mapper.Map<IEnumerable<PublicationGetDto>>(result);
            return Ok(mappedResult);
        }

        [HttpGet]
        [Route("getByName")]
        [AllowAnonymous]
        public async Task<IActionResult> GetPublicationByName(string name)
        {
            var command = new GetPublicationByNameQuery(name);

            var result = await Mediator.Send(command);
            var mappedResult = Mapper.Map<PublicationGetDto>(result);
            return Ok(mappedResult);
        }

        [HttpGet]
        [Route("getByKeyWord")]
        [AllowAnonymous]
        public async Task<IActionResult> GetPublicationsByKeyWord(string word)
        {
            var command = new GetPublicationsByKeyWordQuery(word);

            var result = await Mediator.Send(command);
            var mappedResult = Mapper.Map<IEnumerable<PublicationGetDto>>(result);
            return Ok(mappedResult);
        }

        [HttpDelete]
        [Route("delete")]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Manager")]
        public async Task<IActionResult> DeletePublication([FromQuery] int id)
        {
            var command = new DeletePublicationCommand(id);

            var result = await Mediator.Send(command);
            Logger.LogInformation($"Game deleted Successfully!");
            return Ok(result);
        }
    }
}
