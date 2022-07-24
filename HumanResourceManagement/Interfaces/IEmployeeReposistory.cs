using HumanResourceManagement.Models;

namespace HumanResourceManagement.Interfaces
{
    public interface IEmployeeReposistory
    {
        public Employee? GetEmployee(int id);
        public void DeleteEmployee(Employee employee);
        public void UpdateEmployee(Employee employee);
        public void AddEmployee(Employee employee);
        public Employee? FindEmployeeByEmail(string email);
        public Employee? FindEmployeeByPhoneNumber(string phoneNumber);
    }
}
