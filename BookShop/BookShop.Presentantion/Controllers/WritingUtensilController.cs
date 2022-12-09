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
        public async Task<IActionResult> CreateUtensil([FromBody] UtensilDto utensil)
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
        public async Task<IActionResult> GetById(int id)
        {
            var command = new GetSingleUtensilQuery(id);
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
        public async Task<IActionResult> GetUtensils()
        {
            var command = new GetUtensilsQuery();

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

        [HttpDelete]
        [Route("delete")]
        public async Task<IActionResult> DeleteUtensil(int id)
        {
            var command = new DeleteUtensilCommand(id);

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

        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> UpdateUtensil([FromBody] UtensilDto utensil, int id)
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
