using AutoMapper;
using HumanResourceManagement.Dtos;
using HumanResourceManagement.Models;
using HumanResourceManagement.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace HumanResourceManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;
        private readonly IMapper _mapper;

        public UserController(UserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpGet("profile")]
        [Authorize(Roles = "employee, hr")]
        public IActionResult GetUserProfile() 
        {
            var userId = HttpContext.User.FindFirstValue(ClaimTypes.Name);
            int id = Convert.ToInt32(userId);
            var employee = _userService.GetUserDetails(id);

            if (employee == null)
            {
                return BadRequest("user not found");
            }

            var employeeData = _mapper.Map<Employee, UserDto>(employee);

            return Ok(employeeData);
        }

        [HttpPost("edit")]
        [Authorize(Roles = "employee, hr")]
        public IActionResult EditProfile(UserDto user)
        {
            if (ModelState.IsValid == false)
            {
                return BadRequest("user data is not valid");
            }

            _userService.EditUserProfile(user);
            return Ok();
        }
    }
}
