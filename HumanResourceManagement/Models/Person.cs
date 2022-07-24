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
        public int PhoneNumber { get; set; }
        public short Age { get; set; }
        [StringLength(20)]
        public string Gender { get; set; } = string.Empty; 
        [Required, StringLength(50)]
        public string Roles { get; set; } = string.Empty;
    }
}
