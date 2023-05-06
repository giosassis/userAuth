using userRole.Models;

namespace userRole.Repository.Interface
{
    public interface IUserRepository
    {
        Task<User> GetByIdAsync(int id);
        Task<User> GetByRegistrationNumberAsync(string registrationNumber);
        Task<List<User>> GetAllAsync();
        Task AddAsync(User user);
        Task UpdateAsync(User user);
        Task RemoveAsync(User user);
        Task<bool> UserExistsAsync(int id);
        Task<bool> UserExistsByRegistrationNumberAsync(string registrationNumber);
        Task SaveChangesAsync();
    }
}
