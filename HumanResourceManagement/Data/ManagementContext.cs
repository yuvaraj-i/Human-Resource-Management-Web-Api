using HumanResourceManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace HumanResourceManagement.Data
{
    public class ManagementContext : DbContext
    {
        public ManagementContext(DbContextOptions<ManagementContext>options): base(options) { }

        public DbSet<Employee> Employees { get; set; }
    }
}
