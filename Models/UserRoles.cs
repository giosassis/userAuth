using System.ComponentModel.DataAnnotations;

namespace userRole.Models
{
    public class UserRole
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public virtual ICollection<Roles>? Roles { get; set; }
    }
}
