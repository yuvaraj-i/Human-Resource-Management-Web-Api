using HumanResourceManagement.Dtos;
using HumanResourceManagement.Interfaces;
using HumanResourceManagement.Models;

namespace HumanResourceManagement.Services
{
    public class UserService
    {
        private readonly IEmployeeReposistory _employeeReposistory;

        public UserService(IEmployeeReposistory employeeReposistory)
        {
            _employeeReposistory = employeeReposistory;
        }

        public Employee? GetUserDetails(int id)
        {
            var employee = _employeeReposistory.GetEmployee(id);

            return employee;
        }

        public void EditUserProfile(UserDto user)
        {
            throw new NotImplementedException();
        }
    }
}
