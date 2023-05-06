using userRole.Models;

namespace userRole.Data.Dtos
{
    public class ReadRolePermissionDto
    {
        public int Id { get; set; }
        public int? RoleId { get; set; }
        public Roles? Role { get; set; }
        public int? PermissionId { get; set; }
        public Permission? Permission { get; set; }
    }
}
