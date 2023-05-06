using System.ComponentModel.DataAnnotations;

namespace userRole.Models
{
    public class Roles
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string? Name { get; set; }

        [StringLength(250)]
        public string? Description { get; set; }

        public virtual ICollection<UserRole>? UserRoles { get; set; }

        public virtual ICollection<RolePermission>? RolePermissions { get; set; }
    }
}
