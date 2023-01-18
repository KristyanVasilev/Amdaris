namespace BookShop.Presentantion.Controllers
{
    using BookShop.Application.Email;
    using BookShop.Application.Orders.Commands.CreateOrder;
    using BookShop.Presentantion.DTOs;
    using Microsoft.AspNetCore.Mvc;
    using Newtonsoft.Json;

    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : BaseController<FilesController>
    {
        private readonly IEmailSender emailSender;

        public OrderController(IEmailSender emailSender)
        {
            this.emailSender = emailSender;
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateOrder([FromBody] OrderPostDto orderPostDto)
        {
            var command = Mapper.Map<CreateOrderCommand>(orderPostDto);
            var emailHeader = $"Dear {orderPostDto.UserName} with address: {orderPostDto.Address}";

            var result = await Mediator.Send(command);
            if (!result.Contains("don't have enough quantity!"))
            {
                this.emailSender.SendEmailAsync("Kristiyanvasilev02@gmail.com", "BookShop", $"{orderPostDto.Email}", "Successfuly create a order!", emailHeader + result);
            }
            
            return Ok(JsonConvert.SerializeObject(result));
        }
    }
}
