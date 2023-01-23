namespace BookShop.Presentantion.Controllers
{
    using BookShop.Application.Games.Commands.CreateGame;
    using BookShop.Application.Games.Commands.DeleteGame;
    using BookShop.Application.Games.Commands.UnDeleteGame;
    using BookShop.Application.Games.Commands.UpdateGame;
    using BookShop.Application.Games.Queries.GetGameById;
    using BookShop.Application.Games.Queries.GetGameByKeyWord;
    using BookShop.Application.Games.Queries.GetGameByName;
    using BookShop.Application.Games.Queries.GetGames;
    using BookShop.Application.Games.Queries.GetGamesByGenre;
    using BookShop.Presentantion.DTOs;
    using BookShop.Presentantion.Filters;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Identity.Web.Resource;

    [RequiredScope(RequiredScopesConfigurationKey = "AzureAd:Scopes")]
    [Authorize(AuthenticationSchemes = "Bearer")]
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : BaseController<GameController>
    {
        [HttpPost]
        [Route("create")]
        [ValidateModel]    
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Manager")]
        public async Task<IActionResult> CreateGame([FromBody] GamePostDto game)
        {
            Logger.LogInformation(message: $"Request recieved by Controller: {nameof(GameController)}, Action: {nameof(CreateGame)}, DateTime: {DateTime.Now}");
            var command = Mapper.Map<CreateGameCommand>(game);

            var result = await Mediator.Send(command);
            return Created("/game", result);
        }

        [HttpPost]
        [Route("unDelete")]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Manager")]
        public async Task<IActionResult> UnDeleteGame(string gameName)
        {
            var command = new UnDeleteGameCommand(gameName);

            var result = await Mediator.Send(command);
            var mappedResult = Mapper.Map<GameGetDto>(result);
            return Ok(mappedResult);
        }

        [HttpPost("update/{id}")]
        [ValidateModel]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Manager")]
        public async Task<IActionResult> UpdateGame([FromBody] GamePostDto gamePostDto, int id)
        {
            var command = new UpdateGameCommand
            {
                Id = id,
                Name = gamePostDto.Name,
                Price = gamePostDto.Price,
                Manufacturer = gamePostDto.Manufacturer,
                Description = gamePostDto.Description,
                Genre = gamePostDto.Genre,
                Images = gamePostDto.Images,
            };

            var result = await Mediator.Send(command);
            return Ok(result);
        }

        [HttpGet]
        [Route("all")]
        [AllowAnonymous]
        public async Task<IActionResult> GetGames()
        {
            var command = new GetGamesQuery();

            var result = await Mediator.Send(command);
            var mappedResult = Mapper.Map<IEnumerable<GameGetDto>>(result);

            Logger.LogInformation($"We got {result.Count()} games");
            return Ok(mappedResult);
        }

        [HttpGet]
        [Route("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetById(int id)
        {
            var command = new GetGameByIdQuery(id);

            var result = await Mediator.Send(command);
            var mappedResult = Mapper.Map<GameGetDto>(result);
            return Ok(mappedResult);
        }

        [HttpGet]
        [Route("getByGenre")]
        [AllowAnonymous]
        public async Task<IActionResult> GetGameByGenre(string genreName)
        {
            var command = new GetGamesByGenreQuery(genreName);

            var result = await Mediator.Send(command);
            var mappedResult = Mapper.Map<IEnumerable<GameGetDto>>(result);
            return Ok(mappedResult);
        }

        [HttpGet]
        [Route("getByName")]
        [AllowAnonymous]
        public async Task<IActionResult> GetGameByName(string name)
        {
            var command = new GetGameByNameQuery(name);

            var result = await Mediator.Send(command);
            var mappedResult = Mapper.Map<GameGetDto>(result);
            return Ok(mappedResult);
        }

        [HttpGet]
        [Route("getByKeyWord")]
        [AllowAnonymous]
        public async Task<IActionResult> GetGamesByKeyWord(string word)
        {
            var command = new GetGameByKeyWordQuery(word);

            var result = await Mediator.Send(command);
            var mappedResult = Mapper.Map<IEnumerable<GameGetDto>>(result);
            return Ok(mappedResult);
        }

        [HttpDelete]
        [Route("delete")]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Manager")]
        public async Task<IActionResult> DeleteGame([FromQuery] int id)
        {
            var command = new DeleteGameCommand(id);

            var result = await Mediator.Send(command);
            Logger.LogInformation($"Game deleted Successfully!");
            return Ok(result);
        }
    }
}
