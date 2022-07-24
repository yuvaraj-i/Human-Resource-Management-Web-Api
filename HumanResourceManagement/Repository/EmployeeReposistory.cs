using HumanResourceManagement.Data;
using HumanResourceManagement.Interfaces;
using HumanResourceManagement.Models;

namespace HumanResourceManagement.Repository
{
    public class EmployeeReposistory : IEmployeeReposistory
    {
        private readonly ManagementContext managementContext;

        public EmployeeReposistory(ManagementContext managementContext)
        {
            this.managementContext = managementContext;
        }

        public void DeleteEmployee(Employee employee)
        {
            managementContext.Employees.Remove(employee);
            managementContext.SaveChanges();
        }

        public Employee? GetEmployee(int id)
        {
            return managementContext.Employees.Find(id);
        }

        public void UpdateEmployee(Employee employee)
        {
            managementContext.Employees.Update(employee);
            managementContext.SaveChanges();
        }

        public void AddEmployee(Employee employee)
        {
            managementContext.Employees.Add(employee);
            managementContext.SaveChanges();
        }

        public Employee? FindEmployeeByEmail(string email)
        {
            var employee = managementContext.Employees.Where(x => x.Email == email).FirstOrDefault<Employee>();

            return employee;
        }

        public Employee? FindEmployeeByPhoneNumber(string phoneNumber)
        {
            var employee = managementContext.Employees.Where(x => x.PhoneNumber == phoneNumber).FirstOrDefault<Employee>();

            return employee;
        }
    }
}
