using HumanResourceManagement.Dtos;
using HumanResourceManagement.Interfaces;
using HumanResourceManagement.Models;

namespace HumanResourceManagement.Services
{
    public class HrOperationsService
    {
        private readonly IEmployeeReposistory _employeeReposistory;

        public HrOperationsService(IEmployeeReposistory employeeReposistory)
        {
            _employeeReposistory = employeeReposistory;
        }

        public void AddEmployee(Employee employee)
        {
            var employeeByEmail = _employeeReposistory.FindEmployeeByEmail(employee.Email);
            var employeeByPhoneNumber = _employeeReposistory.FindEmployeeByPhoneNumber(employee.PhoneNumber);

            if (employeeByEmail != null || employeeByPhoneNumber != null)
            {
                throw new ArgumentException($"user data already exits");
            }

            _employeeReposistory.AddEmployee(employee);
        }

        public void DeleteEmployeeById(int id)
        {
            var employee = _employeeReposistory.GetEmployee(id);

            if (employee == null)
            {
                throw new ArgumentException($"user with id:{id} not found");
            }

            _employeeReposistory.DeleteEmployee(employee);
        }

        public void EditEmployeeDetails(int id, EmployeeEditRequestDto employeeUpdateData)
        {
            if (id != employeeUpdateData.Id)
            {
                throw new InvalidDataException("Invalid data");
            }

            var employee = _employeeReposistory.GetEmployee(id);

            if (employee == null)
            {
                throw new ArgumentException($"user with id:{id} not found");
            }

            if (employee.Roles.ToLower().Equals("hr") & employeeUpdateData.Roles.ToLower().Equals("hr") == false)
            {
                throw new InvalidDataException("can't update role of other HR");
            }

            employee.FisrtName = employeeUpdateData.FisrtName;
            employee.LastName = employeeUpdateData.LastName;
            employee.PhoneNumber = employeeUpdateData.PhoneNumber;
            employee.Email = employeeUpdateData.Email;
            employee.DateOfJoining = employeeUpdateData.DateOfJoining;
            employee.CompanyLocation = employeeUpdateData.CompanyLocation;
            employee.WorkingStatus = employeeUpdateData.WorkingStatus;
            employee.Department = employeeUpdateData.Department;
            employee.Designation = employeeUpdateData.Designation;
            employee.Roles = employeeUpdateData.Roles;

            _employeeReposistory.UpdateEmployee(employee);
        }

        public Employee? GetEmployee(int id)
        {
            return _employeeReposistory.GetEmployee(id);
        }
    }
}
