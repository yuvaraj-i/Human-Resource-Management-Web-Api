using HumanResourceManagement.Dtos;
using HumanResourceManagement.Exceptions;
using HumanResourceManagement.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HumanResourceManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly HomeService _homeService;

        public HomeController(HomeService homeService)
        {
            _homeService = homeService;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult AuthenticateUser(UserLoginDto userLoginDetails)
        {
            try
            {
                var token = _homeService.AuthenticateUser(userLoginDetails);
                return Ok(token);
            }

            catch (BadCredentialsException e)
            {
                return BadRequest(e.Message);
            }
        }

        //public IActionResult SignUpUser()
        //{
        //    return BadRequest();
        //}

    }
}
