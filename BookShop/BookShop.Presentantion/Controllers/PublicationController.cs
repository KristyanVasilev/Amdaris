namespace BookShop.Presentantion.Controllers
{
    using BookShop.Application.Publications.Commands.CreatePublication;
    using BookShop.Application.Publications.Commands.DeletePublication;
    using BookShop.Application.Publications.Commands.UpdatePublication;
    using BookShop.Application.Publications.Queries.GetPublication;
    using BookShop.Application.Publications.Queries.GetSinglePublication;
    using BookShop.Presentantion.Dto;
    using BookShop.Presentantion.Filters;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class PublicationController : BaseController<PublicationController>
    {
        [HttpPost]
        [Route("create")]
        [ValidateModel]
        public async Task<IActionResult> CreatePublication([FromBody] PublicationPostDto publication)
        {
            var command = Mapper.Map<CreatePublicationCommand>(publication);

            var result = await Mediator.Send(command);
            return Created("/publication", result);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var command = new GetSinglePublicationQuery(id);

            var result = await Mediator.Send(command);
            var mappedResult = Mapper.Map<PublicationGetDto>(result);
            return Ok(mappedResult);
        }

        [HttpGet]
        [Route("all")]
        public async Task<IActionResult> GetPublications()
        {
            var command = new GetPublicationsQuery();

            var result = await Mediator.Send(command);
            var mappedResult = Mapper.Map<IEnumerable<PublicationGetDto>>(result);
            return Ok(mappedResult);
        }

        [HttpDelete]
        [Route("delete")]
        public async Task<IActionResult> DeletePublication(int id)
        {
            var command = new DeletePublicationCommand(id);

            var result = await Mediator.Send(command);
            return Ok(result);
        }

        [HttpPut]
        [Route("update")]
        [ValidateModel]
        public async Task<IActionResult> UpdatePublication([FromBody] PublicationPutDto publication, int id)
        {
            publication.Id = id;
            var command = Mapper.Map<UpdatePublicationCommand>(publication);

            var result = await Mediator.Send(command);
            return Ok(result);
        }
    }
}
