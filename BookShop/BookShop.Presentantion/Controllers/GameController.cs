namespace BookShop.Presentantion.Controllers
{
    using BookShop.Application.Games.Commands.CreateGame;
    using BookShop.Application.Games.Commands.DeleteGame;
    using BookShop.Application.Games.Commands.UpdateGame;
    using BookShop.Application.Games.Queries.GetGames;
    using BookShop.Application.Games.Queries.GetSingleGame;
    using BookShop.Presentantion.Dto;

    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class GameController : BaseController<GameController>
    {
        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateGame([FromBody] GamePostDto game)
        {
            var command = Mapper.Map<CreateGameCommand>(game);

            var result = await Mediator.Send(command);
            return Created("/game", result);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var command = new GetSingleGameQuery(id);

            var result = await Mediator.Send(command);
            var mappedResult = Mapper.Map<GameGetDto>(result);
            return Ok(mappedResult);
        }

        [HttpGet]
        [Route("all")]
        public async Task<IActionResult> GetGames()
        {
            //Logger.LogInformation($"Request recieved by Controller: {nameof(GameController)}, Action: {ControllerAction}," +
            //    "DateTime: {DateTime}", new object[] { nameof(GameController), nameof(GetGames), DateTime.Now.ToString() });

            Logger.LogInformation(message: $"Request recieved by Controller: {nameof(GameController)}, Action: {nameof(GetGames)}, DateTime: {DateTime.Now}");

            var command = new GetGamesQuery();

            var result = await Mediator.Send(command);
            var mappedResult = Mapper.Map<IEnumerable<GameGetDto>>(result);

            Logger.LogInformation($"We got {result.Count()} games");
            return Ok(mappedResult);
        }

        [HttpDelete]
        [Route("delete")]
        public async Task<IActionResult> DeleteGame(int id)
        {
            var command = new DeleteGameCommand(id);

            var result = await Mediator.Send(command);
            Logger.LogInformation($"Game deleted Successfully!");
            return Ok(result);
        }

        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> UpdateGame([FromBody] GamePostDto game, int id)
        {
            var command = new UpdateGameCommand
            {
                Id = id,
                Name = game.Name,
                Price = game.Price,
                Manufacturer = game.Manufacturer,
                Description = game.Description,
                Genre = game.Genre,
                Images = game.Images,
            };

            var result = await Mediator.Send(command);
            return Ok(result);
        }
    }
}
