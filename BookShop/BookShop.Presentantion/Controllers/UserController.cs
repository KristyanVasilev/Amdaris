using BookShop.Domain;
using BookShop.Presentantion.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BookShop.Presentantion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> userManager;

        private readonly SignInManager<ApplicationUser> signInManager;

        public UserController(
            UserManager<ApplicationUser> _userManager,
            SignInManager<ApplicationUser> _signInManager)
        {
            userManager = _userManager;
            signInManager = _signInManager;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody] RegisterDto model)
        {

            var user = new ApplicationUser()
            {
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                UserName = model.UserName,
            };

            var result = await userManager.CreateAsync(user, model.Password);
            foreach (var item in result.Errors)
            {
                ModelState.AddModelError("", item.Description);
            }

            return Ok(model);
        }

        //[HttpPost]
        //[AllowAnonymous]
        //public async Task<IActionResult> Login(LoginDto model)
        //{

        //    var user = await userManager.FindByNameAsync(model.UserName);

        //    if (user != null)
        //    {
        //        var result = await signInManager.PasswordSignInAsync(user, model.Password, false, false);

        //        if (result.Succeeded)
        //        {
        //            return Ok($"Hi, {user.FirstName}!");
        //        }
        //    }

        //    return NotFound("Invalid login");
        //}
    }
}
