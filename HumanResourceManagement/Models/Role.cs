using System.ComponentModel.DataAnnotations;

namespace HumanResourceManagement.Models
{
    public class Role
    {
        public int Id { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
    }
}
