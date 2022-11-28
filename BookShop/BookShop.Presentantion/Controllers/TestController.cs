using Microsoft.AspNetCore.Mvc;

namespace BookShop.Presentantion.Controllers

{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [HttpGet]
        [Route("get")]
        public IActionResult GetCurrentTime()
        {
            return Ok(new { currentTime = DateTime.Now.ToLocalTime() });
        }
    }
}
