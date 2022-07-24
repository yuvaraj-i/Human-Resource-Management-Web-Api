using System.ComponentModel.DataAnnotations;

namespace HumanResourceManagement.Dtos
{
    public class EmployeeEditRequestDto : EmployeeDto
    {
        [Required]
        public bool WorkingStatus { get; set; } = true;
        [Required]
        public int Id { get; set; }
    }
}
