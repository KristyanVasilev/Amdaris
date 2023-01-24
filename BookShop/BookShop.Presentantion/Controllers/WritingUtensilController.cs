namespace BookShop.Presentantion.Controllers
{
    using BookShop.Application.Games.Queries.GetGameByKeyWord;
    using BookShop.Application.WritingUtensils.Commands.CreateUtensils;
    using BookShop.Application.WritingUtensils.Commands.DeleteUtensils;
    using BookShop.Application.WritingUtensils.Commands.UnDeleteUtensils;
    using BookShop.Application.WritingUtensils.Commands.UpdateUtensils;
    using BookShop.Application.WritingUtensils.Queries.GetUtensilById;
    using BookShop.Application.WritingUtensils.Queries.GetUtensilByKeyWord;
    using BookShop.Application.WritingUtensils.Queries.GetUtensils;
    using BookShop.Application.WritingUtensils.Queries.GetUtensilsByColor;
    using BookShop.Application.WritingUtensils.Queries.GetUtensilsByName;
    using BookShop.Presentantion.DTOs;
    using BookShop.Presentantion.Filters;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Identity.Web.Resource;
    using Newtonsoft.Json;

    [RequiredScope(RequiredScopesConfigurationKey = "AzureAd:Scopes")]
    [Authorize(AuthenticationSchemes = "Bearer")]
    [Route("api/[controller]")]
    [ApiController]
    public class WritingUtensilController : BaseController<WritingUtensilController>
    {
        [HttpPost]
        [Route("create")]
        [ValidateModel]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Manager")]
        public async Task<IActionResult> CreateUtensil([FromBody] UtensilPostDto utensil)
        {
            Logger.LogInformation(message: $"Request recieved by Controller: {nameof(WritingUtensilController)}, Action: {nameof(CreateUtensil)}, DateTime: {DateTime.Now}");
            var command = Mapper.Map<CreateUtensilsCommand>(utensil);

            var result = await Mediator.Send(command);
            return Created("/writingUtensil", result);
        }

        [HttpPost]
        [Route("delete")]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Manager")]
        public async Task<IActionResult> DeleteUtensil([FromBody] int id)
        {
            var command = new DeleteUtensilCommand(id);

            var result = await Mediator.Send(command);
            Logger.LogInformation($"Utensil deleted Successfully!");
            return Ok(JsonConvert.SerializeObject(result));
        }

        [HttpPost]
        [Route("unDelete")]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Manager")]
        public async Task<IActionResult> UnDeleteGame(string utensilName)
        {
            var command = new UnDeleteUtensilCommand(utensilName);

            var result = await Mediator.Send(command);
            var mappedResult = Mapper.Map<UtensilGetDto>(result);
            return Ok(mappedResult);
        }

        [HttpPost("update/{id}")]
        [ValidateModel]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Manager")]
        public async Task<IActionResult> UpdateUtensil([FromBody] UtensilPostDto utensil, int id)
        {
            var command = new UpdateUtensilsCommand
            {
                Id = id,
                Name = utensil.Name,
                Price = utensil.Price,
                Color = utensil.Color,
                Manufacturer = utensil.Manufacturer,
                Images = utensil.Images,
                KeyWords = utensil.KeyWords,
                Quantity = utensil.Quantity,
                WritingUtensilsType = utensil.WritingUtensilsType,
            };

            var result = await Mediator.Send(command);
            return Ok(result);
        }

        [HttpGet]
        [Route("all")]
        [AllowAnonymous]
        public async Task<IActionResult> GetUtensils()
        {
            var command = new GetUtensilsQuery();

            var result = await Mediator.Send(command);
            var mappedResult = Mapper.Map<IEnumerable<UtensilGetDto>>(result);
            return Ok(mappedResult);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var command = new GetUtensilByIdQuery(id);

            var result = await Mediator.Send(command);
            var mappedResult = Mapper.Map<UtensilGetDto>(result);
            return Ok(mappedResult);
        }

        [HttpGet]
        [Route("getByColor")]
        [AllowAnonymous]
        public async Task<IActionResult> GetUtensilsByColor(string color)
        {
            var command = new GetUtensilsByColorQuery(color);

            var result = await Mediator.Send(command);
            var mappedResult = Mapper.Map<IEnumerable<UtensilGetDto>>(result);
            return Ok(mappedResult);
        }

        [HttpGet]
        [Route("getByKeyWord")]
        [AllowAnonymous]
        public async Task<IActionResult> GetUtensilByKeyWord(string word)
        {
            var command = new GetUtensilByKeyWordQuery(word);

            var result = await Mediator.Send(command);
            var mappedResult = Mapper.Map<IEnumerable<UtensilGetDto>>(result);
            return Ok(mappedResult);
        }

        [HttpGet]
        [Route("getByName")]
        [AllowAnonymous]
        public async Task<IActionResult> GetUtensilsByName(string name)
        {
            var command = new GetUtensilsByNameQuery(name);

            var result = await Mediator.Send(command);
            var mappedResult = Mapper.Map<UtensilGetDto>(result);
            return Ok(mappedResult);
        }
    }
}
