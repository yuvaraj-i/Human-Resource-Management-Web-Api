using System.ComponentModel.DataAnnotations;

namespace HumanResourceManagement.Models
{
    public class Person
    {
        [StringLength(50)]
        public string FisrtName { get; set; } = string.Empty;
        [StringLength(50)]
        public string? LastName { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
        public Address PermanentAddress { get; set; } = new Address();
        public Address PresentAddress { get; set; } = new Address();
        [StringLength(50)]
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public short Age { get; set; }
        [StringLength(20)]
        public string Gender { get; set; } = string.Empty; 
    }
}
