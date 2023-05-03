using userRole.Models;

namespace userRole.Repository.Interface
{
    public interface IPermissionRepository
    {
        Task<IEnumerable<Permission>> GetPermissionsAsync();
    }
}
