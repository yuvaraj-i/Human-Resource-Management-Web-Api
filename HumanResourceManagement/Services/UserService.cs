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
            var employee = new Employee()
            {
                Age = user.Age,
                FisrtName = user.FisrtName,
                LastName = user.LastName,
                Email = user.Email,
                PermanentAddress = user.PermanentAddress,
                PresentAddress = user.PresentAddress,
                Gender = user.Gender,
                DateOfBirth = user.DateOfBirth,
                PhoneNumber = user.PhoneNumber,
            };

            _employeeReposistory.UpdateEmployee(employee);
        }
    }
}
