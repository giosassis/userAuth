using userRole.Data.Dtos;
using userRole.Models;

namespace userRole.Service.Interface
{
    public interface IUserService
    {
        Task<List<ReadUserDto>> GetAllUsers();
        Task<ReadUserDto> GetUserByIdAsync(int id);
        Task<ReadUserDto> GetUserByMatriculaAsync(string registrationNumber);
        Task<Users> CreateUserAsync(CreateUserDto userDto);
        Task<UpdateUserDto> UpdateUserAsync(int userId, UpdateUserDto userDto);
        Task DeleteUserAsync(int userId);
    }
}
