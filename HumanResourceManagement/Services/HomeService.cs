using HumanResourceManagement.Dtos;
using HumanResourceManagement.Exceptions;
using HumanResourceManagement.Interfaces;
using HumanResourceManagement.Models;

namespace HumanResourceManagement.Services
{
    public class HomeService
    {
        private readonly IJwtTokenManager _jwtTokenManager;
        private readonly IEmployeeReposistory _employeeReposistory;

        public HomeService(IJwtTokenManager jwtTokenManager, IEmployeeReposistory employeeReposistory)
        {
            _jwtTokenManager = jwtTokenManager;
            _employeeReposistory = employeeReposistory;
        }

        public Token AuthenticateUser(UserLoginDto userLogincredentials)
        {
            var employee = _employeeReposistory.FindEmployeeByEmail(userLogincredentials.Email);

            if (employee == null)
            {
                throw new BadCredentialsException("invalid user credentials");
            }

            return _jwtTokenManager.GenerateUserToken(employee.Id+"", employee.Roles);
        }
    }
}
