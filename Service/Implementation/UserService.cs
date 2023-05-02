using Microsoft.AspNetCore.Identity;
using AutoMapper;
using BCrypt;
using userRole.Data.Dtos;
using userRole.Models;
using userRole.Repository.Interface;
using userRole.Service.Interface;

namespace userRole.Service.Implementation
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IPasswordHasher<Users> _passwordHasher;

        public UserService(IUserRepository userRepository, IMapper mapper, IPasswordHasher<Users> passwordHasher)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _passwordHasher = passwordHasher;
        }

        public async Task<ReadUserDto> GetUserByIdAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            return _mapper.Map<ReadUserDto>(user);
        }

        public async Task<ReadUserDto> GetUserByMatriculaAsync(string registrationNumber)
        {
            var user = await _userRepository.GetByMatriculaAsync(registrationNumber);
            return _mapper.Map<ReadUserDto>(user);
        }

        public async Task<ReadUserDto> AuthenticateAsync(string registrationNumber, string password)
        {
            var user = await _userRepository.GetByMatriculaAsync(registrationNumber);
            var passwordHasher = _passwordHasher.VerifyHashedPassword(user, user.Password, password);

            if (!passwordHasher == PasswordVerificationResult.Success)
            {

                throw new Exception("Invalid matricula or password");
            }
        }

        public async Task CreateAsync(CreateUserDto userDto)
        {
            if (await _userRepository.UserExistsByRegistrationNumberAsync(userDto.Matricula))
            {
                throw new Exception("Registration number already exists");
            }

            var user = _mapper.Map<Users>(userDto);
            user.Password = _passwordHasher.HashPassword(user, user.Password);

            await _userRepository.AddAsync(user);
            await _userRepository.SaveChangesAsync();
        }

        public async Task UpdateAsync(int id, UpdateUserDto userDto)
        {
            var user = await _userRepository.GetByIdAsync(id);

            if (user == null)
            {
                throw new Exception("User not found");
            }

            _mapper.Map(userDto, user);

            await _userRepository.UpdateAsync(user);
            await _userRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);

            if (user == null)
            {
                throw new Exception("User not found");
            }

            await _userRepository.RemoveAsync(user);
            await _userRepository.SaveChangesAsync();
        }
    }
}
