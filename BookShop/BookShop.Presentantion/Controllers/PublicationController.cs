namespace BookShop.Presentantion.Controllers
{
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

        public PublicationController(IMediator mediator)
        {
            this.mediator= mediator;
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreatePublication([FromBody] PublicationDto publication)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var command = new CreatePublicationCommand
            {
                Name = publication.Name,
                Author = publication.Author,
                Price = publication.Price,
                PageCount = publication.PageCount,
                Description = publication.Description,
                Genre = publication.Genre,
                PublicationType = publication.PublicationType,
            };

            var result = await this.mediator.Send(command);

            return Ok(result);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var command = new GetSinglePublicationQuery(id);
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
        public async Task<IActionResult> GetPublications()
        {
            var command = new GetPublicationsQuery();

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
        public async Task<IActionResult> DeletePublications(int id)
        {
            var command = new DeletePublicationCommand(id);

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
        public async Task<IActionResult> UpdatePublication([FromBody] PublicationDto publication, int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var command = new UpdatePublicationCommand
            {
                Id = id,
                Name = publication.Name,
                Author = publication.Author,
                Price = publication.Price,
                PageCount = publication.PageCount,
                Description = publication.Description,
                Genre = publication.Genre,
                PublicationType = publication.PublicationType,
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
