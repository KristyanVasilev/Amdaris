﻿namespace BookShop.Presentantion.Controllers
{
    using BookShop.Application.WritingUtensils.Commands.CreateUtensils;
    using BookShop.Application.WritingUtensils.Commands.DeleteUtensils;
    using BookShop.Application.WritingUtensils.Commands.UnDeleteUtensils;
    using BookShop.Application.WritingUtensils.Commands.UpdateUtensils;
    using BookShop.Application.WritingUtensils.Queries.GetUtensilById;
    using BookShop.Application.WritingUtensils.Queries.GetUtensils;
    using BookShop.Application.WritingUtensils.Queries.GetUtensilsByColor;
    using BookShop.Application.WritingUtensils.Queries.GetUtensilsByType;
    using BookShop.Presentantion.Dto;
    using BookShop.Presentantion.Filters;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class WritingUtensilController : BaseController<WritingUtensilController>
    {
        [HttpPost]
        [Route("create")]
        [ValidateModel]
        public async Task<IActionResult> CreateUtensil([FromBody] UtensilPostDto utensil)
        {
            var command = Mapper.Map<CreateUtensilsCommand>(utensil);

            var result = await Mediator.Send(command);
            return Created("/writingUtensil", result);
        }

        [HttpPost]
        [Route("unDelete")]
        public async Task<IActionResult> UnDeleteGame(string utensilName)
        {
            var command = new UnDeleteUtensilCommand(utensilName);

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
        public async Task<IActionResult> GetUtensilsByColor(string color)
        {
            var command = new GetUtensilsByColorQuery(color);

            var result = await Mediator.Send(command);
            var mappedResult = Mapper.Map<IEnumerable<UtensilGetDto>>(result);
            return Ok(mappedResult);
        }

        [HttpGet]
        [Route("getByType")]
        public async Task<IActionResult> GetUtensilsByType(string typeName)
        {
            var command = new GetUtensilsByTypeQuery(typeName);

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
        [ValidateModel]
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
                WritingUtensilsType = utensil.WritingUtensilsType,
            };

            var result = await Mediator.Send(command);
            return Ok(result);
        }
    }
}
