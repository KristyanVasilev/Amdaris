namespace BookShop.Presentantion.Controllers
{
    using AutoMapper;
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
        public readonly IMapper mapper;

        public GameController(IMediator mediator, IMapper mapper)
        {
            this.mediator = mediator;
            this.mapper = mapper;
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateGameAsync([FromBody] GamePostDto game)
        {
            var command = this.mapper.Map<CreateGameCommand>(game);

            var result = await this.mediator.Send(command);
            return Ok(result);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var command = new GetSingleGameQuery(id);

            var result = await this.mediator.Send(command);
            var mappedResult = this.mapper.Map<GameGetDto>(result);
            return Ok(mappedResult);
        }

        [HttpGet]
        [Route("all")]
        public async Task<IActionResult> GetGamesAsync()
        {
            var command = new GetGamesQuery();

            var result = await this.mediator.Send(command);
            var mappedResult = this.mapper.Map<IEnumerable<GameGetDto>>(result);
            return Ok(mappedResult);
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
        public async Task<IActionResult> UpdateGameAsync([FromBody] GamePostDto game, int id)
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
