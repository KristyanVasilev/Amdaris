namespace BookShop.Presentantion.Controllers
{
    using AutoMapper;
    using BookShop.Application.WritingUtensils.Commands.CreateUtensils;
    using BookShop.Application.WritingUtensils.Commands.DeleteUtensils;
    using BookShop.Application.WritingUtensils.Commands.UpdateUtensils;
    using BookShop.Application.WritingUtensils.Queries.GetSingleUtensil;
    using BookShop.Application.WritingUtensils.Queries.GetUtensils;
    using BookShop.Presentantion.Dto;

    using MediatR;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class WritingUtensilController : ControllerBase
    {
        public readonly IMediator mediator;
        public readonly IMapper mapper;

        public WritingUtensilController(IMediator mediator, IMapper mapper)
        {
            this.mediator = mediator;
            this.mapper = mapper;
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateUtensilAsync([FromBody] UtensilPostDto utensil)
        {
            var command = this.mapper.Map<CreateUtensilsCommand>(utensil);

            var result = await this.mediator.Send(command);
            return Ok(result);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var command = new GetSingleUtensilQuery(id);

            var result = await this.mediator.Send(command);
            var mappedResult = this.mapper.Map<UtensilGetDto>(result);
            return Ok(result);
        }

        [HttpGet]
        [Route("all")]
        public async Task<IActionResult> GetUtensilsAsync()
        {
            var command = new GetUtensilsQuery();

            var result = await this.mediator.Send(command);
            var mappedResult = this.mapper.Map<IEnumerable<UtensilGetDto>>(result);
            return Ok(result);
        }

        [HttpDelete]
        [Route("delete")]
        public async Task<IActionResult> DeleteUtensilAsync(int id)
        {
            var command = new DeleteUtensilCommand(id);

            var result = await this.mediator.Send(command);
            return Ok(result);
        }

        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> UpdateUtensilAsync([FromBody] UtensilPostDto utensil, int id)
        {
            var command = new UpdateUtensilsCommand
            {
                Id = id,
                Name = utensil.Name,
                Price = utensil.Price,
                Color = utensil.Color,
                Manufacturer = utensil.Manufacturer,
                WritingUtensilsType = utensil.WritingUtensilsType,
            };

            var result = await this.mediator.Send(command);
            return Ok(result);
        }
    }
}
