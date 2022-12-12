namespace BookShop.Presentantion.Controllers
{
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

        public WritingUtensilController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateUtensilAsync([FromBody] UtensilDto utensil)
        {
            var command = new CreateUtensilsCommand
            {
                Name = utensil.Name,
                Price = utensil.Price,
                Color = utensil.Color,
                Manufacturer = utensil.Manufacturer,
                WritingUtensilsType = utensil.WritingUtensilsType,
            };

            var result = await this.mediator.Send(command);

            return Ok(result);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var command = new GetSingleUtensilQuery(id);

            var result = await this.mediator.Send(command);
            return Ok(result);
        }

        [HttpGet]
        [Route("all")]
        public async Task<IActionResult> GetUtensilsAsync()
        {
            var command = new GetUtensilsQuery();

            var result = await this.mediator.Send(command);
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
        public async Task<IActionResult> UpdateUtensilAsync([FromBody] UtensilDto utensil, int id)
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
