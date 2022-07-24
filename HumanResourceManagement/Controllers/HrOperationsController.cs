using AutoMapper;
using HumanResourceManagement.Dtos;
using HumanResourceManagement.Models;
using HumanResourceManagement.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HumanResourceManagement.Controllers
{
    [Route("api/employees")]
    [ApiController]
    public class HrOperationsController : ControllerBase
    {
        private readonly HrOperationsService _hrOperationsService;
        private readonly IMapper _mapper;

        public HrOperationsController(HrOperationsService hrOperationsService, IMapper mapper)
        {
            _hrOperationsService = hrOperationsService;
            _mapper = mapper;
        }

        [HttpPost("add")]
        [Authorize(Roles = "hr")]
        public IActionResult AddEmployeeDetails(EmployeeDto employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("user data is not valid");
            }

            var employeeData = _mapper.Map<EmployeeDto, Employee>(employee);
            employeeData.Roles.ToLower();

            try
            {
                _hrOperationsService.AddEmployee(employeeData);
            }
            catch (ArgumentException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception e)
            {
                return Problem("unable to process your request please try again later");
            }

            return Ok();
        }

        [HttpDelete("delete/{id}")]
        [Authorize(Roles = "hr")]
        public IActionResult DeleteEmployee(int id)
        {
            try
            {
                _hrOperationsService.DeleteEmployeeById(id);
            }
            catch (ArgumentException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception)
            {
                return Problem("unable to process your request please try again later");
            }

            return Ok();
        }

        [HttpPost("update/{id}")]
        [Authorize(Roles = "hr")]
        public IActionResult EditEmployeeDetails(int id, EmployeeEditRequestDto employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("user data is not valid");
            }

            try
            {
                _hrOperationsService.EditEmployeeDetails(id, employee);
            }
            catch (InvalidDataException e)
            {
                return NotFound(e.Message);
            }
            catch (ArgumentException e)
            {
                return NotFound(e.Message);
            }

            catch (Exception)
            {
                return Problem("unable to process your request please try again later");
            }

            return Ok();
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "hr")]
        public IActionResult GetEmployeeById(int id)
        {
            var employee = _hrOperationsService.GetEmployee(id);

            if (employee == null)
            {
                return BadRequest($"user with id:{id} not found");
            }

            var employeeData = _mapper.Map<Employee, EmployeeEditRequestDto>(employee);

            return Ok(employeeData);
        }
    }
}
