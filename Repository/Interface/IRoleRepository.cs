using userRole.Models;

namespace userRole.Repository.Interface
{
    public interface IRoleRepository
    {
        Task<Roles> GetByIdAsync(int id);
        Task<List<Roles>> GetAllAsync();
        Task CreateAsync(Roles role);
        Task UpdateAsync(Roles role);
        Task DeleteAsync(Roles role);
        Task SaveChangesAsync();
    }
}
