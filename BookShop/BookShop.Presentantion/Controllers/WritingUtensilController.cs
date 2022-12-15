namespace BookShop.Presentantion.Controllers
{
    using BookShop.Application.WritingUtensils.Commands.CreateUtensils;
    using BookShop.Application.WritingUtensils.Commands.DeleteUtensils;
    using BookShop.Application.WritingUtensils.Commands.UpdateUtensils;
    using BookShop.Application.WritingUtensils.Queries.GetSingleUtensil;
    using BookShop.Application.WritingUtensils.Queries.GetUtensils;
    using BookShop.Presentantion.Dto;

    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class WritingUtensilController : BaseController<WritingUtensilController>
    {
        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateUtensil([FromBody] UtensilPostDto utensil)
        {
            var command = Mapper.Map<CreateUtensilsCommand>(utensil);

            var result = await Mediator.Send(command);
            return Created("/writingUtensil", result);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var command = new GetSingleUtensilQuery(id);

            var result = await Mediator.Send(command);
            var mappedResult = Mapper.Map<UtensilGetDto>(result);
            return Ok(mappedResult);
        }

        [HttpGet]
        [Route("all")]
        public async Task<IActionResult> GetUtensils()
        {
            var command = new GetUtensilsQuery();

            var result = await Mediator.Send(command);
            var mappedResult = Mapper.Map<IEnumerable<UtensilGetDto>>(result);
            return Ok(mappedResult);
        }

        [HttpDelete]
        [Route("delete")]
        public async Task<IActionResult> DeleteUtensil(int id)
        {
            var command = new DeleteUtensilCommand(id);

            var result = await Mediator.Send(command);
            return Ok(result);
        }

        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> UpdateUtensil([FromBody] UtensilPostDto utensil, int id)
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

            var result = await Mediator.Send(command);
            return Ok(result);
        }
    }
}
