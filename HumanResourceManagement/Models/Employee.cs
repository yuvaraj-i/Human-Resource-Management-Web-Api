using System.ComponentModel.DataAnnotations;

namespace HumanResourceManagement.Models
{
    public class Employee : Person
    {
        public int Id { get; set; }
        [Required, StringLength(50)]
        public string Roles { get; set; } = string.Empty;
        [StringLength(50)]
        public string Department { get; set; } = string.Empty;
        [StringLength(50)]
        public string CompanyLocation { get; set; } = string.Empty;
        [StringLength(50)]
        public string Designation { get; set; } = string.Empty;
        public bool WorkingStatus { get; set; } = true;
        [DataType(DataType.Date)]
        public DateTime DateOfJoining { get; set; }
    }

}
