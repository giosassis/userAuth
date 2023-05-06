using userRole.Models;

namespace userRole.Repository.Interface
{
    public interface IRolePermissionRepository
    {
        Task<List<RolePermission>> GetAllAsync();
        Task<RolePermission> GetByIdAsync(int id);
        Task<RolePermission> CreateAsync(RolePermission rolePermission);
        Task<RolePermission> UpdateAsync(RolePermission rolePermission);
        Task<RolePermission> DeleteAsync(int id);
    }
}
