namespace BookShop.Presentantion.Controllers
{
    using BookShop.Application.Games.Commands.CreateGame;
    using BookShop.Application.Games.Commands.DeleteGame;
    using BookShop.Application.Games.Commands.UpdateGame;
    using BookShop.Application.Games.Queries.GetGames;
    using BookShop.Application.Games.Queries.GetSingleGame;
    using BookShop.Presentantion.Dto;

    using MediatR;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        public readonly IMediator mediator;

        public GameController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateGameAsync([FromBody] GameDto game)
        {
            var command = new CreateGameCommand
            {
                Name = game.Name,
                Price = game.Price,
                Manufacturer = game.Manufacturer,
                Description = game.Description,
                Genre = game.Genre,
            };

            var result = await this.mediator.Send(command);

            return Ok(result);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var command = new GetSingleGameQuery(id);

            var result = await this.mediator.Send(command);
            return Ok(result);
        }

        [HttpGet]
        [Route("all")]
        public async Task<IActionResult> GetGamesAsync()
        {
            var command = new GetGamesQuery();

            var result = await this.mediator.Send(command);
            return Ok(result);

        }

        [HttpDelete]
        [Route("delete")]
        public async Task<IActionResult> DeleteGameAsync(int id)
        {
            var command = new DeleteGameCommand(id);

            var result = await this.mediator.Send(command);
            return Ok(result);
        }

        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> UpdateGameAsync([FromBody] GameDto game, int id)
        {
            var command = new UpdateGameCommand
            {
                Id = id,
                Name = game.Name,
                Price = game.Price,
                Manufacturer = game.Manufacturer,
                Description = game.Description,
                Genre = game.Genre,
            };

            var result = await this.mediator.Send(command);
            return Ok(result);
        }
    }
}
