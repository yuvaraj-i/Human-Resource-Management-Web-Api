using System.ComponentModel.DataAnnotations;

namespace HumanResourceManagement.Models
{
    public class Address
    {
        public int Id { get; set; }
        [StringLength(200)]
        public string Line1 { get; set; } = string.Empty;
        [StringLength(200)]
        public string Line2 { get; set; } = string.Empty;
        [StringLength(20)]
        public string City { get; set; } = string.Empty;
        [StringLength(20)]
        public string Region { get; set; } = string.Empty;
        public int? PostalCode { get; set; }
        [StringLength(20)]
        public string Country { get; set; } = string.Empty;
    }
}
