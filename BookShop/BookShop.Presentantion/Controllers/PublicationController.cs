namespace BookShop.Presentantion.Controllers
{
    using AutoMapper;
    using BookShop.Application.Publications.Commands.CreatePublication;
    using BookShop.Application.Publications.Commands.DeletePublication;
    using BookShop.Application.Publications.Commands.UpdatePublication;
    using BookShop.Application.Publications.Queries.GetPublication;
    using BookShop.Application.Publications.Queries.GetSinglePublication;
    using BookShop.Presentantion.Dto;

    using MediatR;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class PublicationController : ControllerBase
    {
        public readonly IMediator mediator;
        public readonly IMapper mapper;

        public PublicationController(IMediator mediator, IMapper mapper)
        {
            this.mediator = mediator;
            this.mapper = mapper;
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreatePublicationAsync([FromBody] PublicationPostDto publication)
        {
            var command = this.mapper.Map<CreatePublicationCommand>(publication);

            var result = await this.mediator.Send(command);
            return Ok(result);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var command = new GetSinglePublicationQuery(id);

            var result = await this.mediator.Send(command);
            var mappedResult = this.mapper.Map<PublicationGetDto>(result);
            return Ok(mappedResult);
        }

        [HttpGet]
        [Route("all")]
        public async Task<IActionResult> GetPublicationsAsync()
        {
            var command = new GetPublicationsQuery();

            var result = await this.mediator.Send(command);
            var mappedResult = this.mapper.Map<IEnumerable<PublicationGetDto>>(result);
            return Ok(mappedResult);
        }

        [HttpDelete]
        [Route("delete")]
        public async Task<IActionResult> DeletePublicationAsync(int id)
        {
            var command = new DeletePublicationCommand(id);

            var result = await this.mediator.Send(command);
            return Ok(result);
        }

        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> UpdatePublicationAsync([FromBody] PublicationPutDto publication, int id)
        {
            publication.Id = id;
            var command = this.mapper.Map<UpdatePublicationCommand>(publication);

            var result = await this.mediator.Send(command);
            return Ok(result);
        }
    }
}
