using userRole.Models;

namespace userRole.Repository.Interface
{
    public interface IUserRepository
    {
        Task<Users> GetByIdAsync(int id);
        Task<Users> GetByMatriculaAsync(string registrationNumber);
        Task<IEnumerable<Users>> GetAllAsync();
        Task AddAsync(Users user);
        Task UpdateAsync(Users user);
        Task RemoveAsync(Users user);
        Task<bool> UserExistsAsync(int id);
        Task<bool> UserExistsByRegistrationNumberAsync(string registrationNumber);
    }
}
