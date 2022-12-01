using BookShop.Application;
using BookShop.Application.Publications.Commands.CreatePublication;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookShop.Presentantion.Controllers

{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        public readonly IMediator mediator;

        public TestController(IMediator mediator)
        {
            this.mediator= mediator;
        }

        [HttpGet]
        [Route("get")]
        public IActionResult GetCurrentTime()
        {
            return Ok(new { currentTime = DateTime.Now.ToLocalTime() });
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreatePublication()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var command = new CreatePublicationCommand
            {
                Price = 10,
                Name = "The Boys from Biloxi",
                Author = "Grisham",
                PageCount = 400,
                Description = "Some description",
                Genre = new GenreDto { Name = "Horror" },
                PublicationType = "Book",
            };

            var result = await this.mediator.Send(command);

            return Ok(result);
        }
    }
}
