namespace BookShop.Presentantion.Controllers
{
    using BookShop.Application.Games.Commands.CreateGame;
    using BookShop.Application.Games.Commands.DeleteGame;
    using BookShop.Application.Games.Commands.UpdateGame;
    using BookShop.Application.Games.Queries.GetGames;
    using BookShop.Application.Games.Queries.GetSingleGame;
    using BookShop.Application.Publications.Commands.DeletePublication;
    using BookShop.Application.Publications.Commands.UpdatePublication;
    using BookShop.Application.Publications.Queries.GetPublication;
    using BookShop.Application.Publications.Queries.GetSinglePublication;
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
        public async Task<IActionResult> CreateGame([FromBody] GameDto game)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

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
        public async Task<IActionResult> GetById(int id)
        {
            var command = new GetSingleGameQuery(id);
            try
            {
                var result = await this.mediator.Send(command);
                return Ok(result);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpGet]
        [Route("all")]
        public async Task<IActionResult> GetGames()
        {
            var command = new GetGamesQuery();

            try
            {
                var result = await this.mediator.Send(command);
                return Ok(result);
            }
            catch (Exception)
            {
                return NotFound();
            };
        }

        [HttpGet]
        [Route("delete")]
        public async Task<IActionResult> DeleteGame(int id)
        {
            var command = new DeleteGameCommand(id);

            try
            {
                var result = await this.mediator.Send(command);
                return Ok(result);
            }
            catch (Exception)
            {
                return NotFound();
            };
        }

        [HttpPost]
        [Route("update")]
        public async Task<IActionResult> UpdateGame([FromBody] GameDto game, int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var command = new UpdateGameCommand
            {
                Id = id,
                Name = game.Name,
                Price = game.Price,
                Manufacturer = game.Manufacturer,
                Description = game.Description,
                Genre = game.Genre,
            };

            try
            {
                var result = await this.mediator.Send(command);
                return Ok(result);
            }
            catch (Exception)
            {
                return NotFound();
            };
        }
    }
}
