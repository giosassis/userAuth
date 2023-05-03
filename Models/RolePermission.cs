using System.ComponentModel.DataAnnotations;

namespace userRole.Models
{
    public class RolePermission
    {
        [Key]
        public int Id { get; set; }
        public int? RoleId { get; set; }
        public Roles? Role { get; set; }
        public int? PermissionId { get; set; }
        public Permission? Permission { get; set; }
    }
}
