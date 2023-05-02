using userRole.Data.Dtos;

namespace userRole.Service.Interface
{
    public interface IUserService
    {
        Task<ReadUserDto> GetAllUsers(int id);
        Task<ReadUserDto> GetUserByIdAsync(int id);
        Task<ReadUserDto> GetUserByMatriculaAsync(string registrationNumber);
        Task<CreateUserDto> CreateUserAsync(CreateUserDto userDto);
        Task<ReadUserDto> AuthenticateAsync(string registrationNumber, string password);
        Task<UpdateUserDto> UpdateUserAsync(int userId, UpdateUserDto userDto);
        Task DeleteUserAsync(int userId);
    }
}
