using System.ComponentModel.DataAnnotations;

namespace HumanResourceManagement.Dtos
{
    public class EmployeeDto
    {
        [StringLength(50)]
        public string FisrtName { get; set; } = string.Empty;
        [StringLength(50)]
        public string? LastName { get; set; }
        [StringLength(50)]
        public string? Department { get; set; }
        [StringLength(50)]
        public string? CompanyLocation { get; set; }
        [StringLength(50)]
        public string? Designation { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateOfJoining { get; set; }
        public string Roles { get; set; } = string.Empty;
    }
}
