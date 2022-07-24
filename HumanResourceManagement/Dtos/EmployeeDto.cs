using System.ComponentModel.DataAnnotations;

namespace HumanResourceManagement.Dtos
{
    public class EmployeeDto
    {
        [StringLength(50), Required]
        public string FisrtName { get; set; } = string.Empty;
        [StringLength(50), Required]
        public string LastName { get; set; } = string.Empty;
        [StringLength (50), Required]
        public string Email { get; set; } = string.Empty;
        [Required]
        public string PhoneNumber { get; set; } = string.Empty;
        [StringLength(50), Required]
        public string Department { get; set; } = string.Empty;
        [StringLength(50), Required]
        public string CompanyLocation { get; set; } = string.Empty;
        [StringLength(50), Required]
        public string Designation { get; set; } = string.Empty;
        [DataType(DataType.Date), Required]
        public DateTime DateOfJoining { get; set; }
        [Required]
        public string Roles { get; set; } = string.Empty;
    }
}
