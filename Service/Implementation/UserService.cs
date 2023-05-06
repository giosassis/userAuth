using Microsoft.AspNetCore.Identity;
using AutoMapper;
using BCrypt;
using userRole.Data.Dtos;
using userRole.Models;
using userRole.Repository.Interface;
using userRole.Service.Interface;
using System.Security.Cryptography;
using System.Text;
using userRole.Validators;
using FluentValidation;

namespace userRole.Service.Implementation
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;        
        }

        public async Task<List<ReadUserDto>> GetAllUsers()
        {
            var users = await _userRepository.GetAllAsync();
            return _mapper.Map<List<ReadUserDto>>(users);
        }

        public async Task<ReadUserDto> GetUserByIdAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            return _mapper.Map<ReadUserDto>(user);
        }

        public async Task<ReadUserDto> GetByRegistrationNumberAsync(string registrationNumber)
        {
            var user = await _userRepository.GetByRegistrationNumberAsync(registrationNumber);
            return _mapper.Map<ReadUserDto>(user);
        }

        public async Task<User> CreateUserAsync(CreateUserDto userDto)
        {
            var validator = new UserValidator();
            var validationResult = await validator.ValidateAsync(userDto);

            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            string hashedPassword = HashPassword(userDto.Password);

            string registrationNumber = GenerateRegistrationNumber();

            var user = new User
            {
                Name = userDto.Name,
                Email = userDto.Email,
                Password = hashedPassword,
                RegistrationNumber = registrationNumber
            };

            await _userRepository.AddAsync(user);

            return user;
        }

        public async Task<UpdateUserDto> UpdateUserAsync(int id, UpdateUserDto userDto)
        {
            var user = await _userRepository.GetByIdAsync(id);

            if (user == null)
            {
                throw new Exception("User not found");
            }

            _mapper.Map(userDto, user);

            await _userRepository.UpdateAsync(user);
            await _userRepository.SaveChangesAsync();

            return _mapper.Map<UpdateUserDto>(user);
        }


        public async Task DeleteUserAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);

            if (user == null)
            {
                throw new Exception("User not found");
            }

            await _userRepository.RemoveAsync(user);
            await _userRepository.SaveChangesAsync();
        }

        private static string HashPassword(string password)
        {

            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] passwordBytes = Encoding.UTF8.GetBytes(password);

                byte[] hashBytes = sha256.ComputeHash(passwordBytes);

                return Convert.ToBase64String(hashBytes);
            }
        }

        private string GenerateRegistrationNumber()
        {
            Random rnd = new();
            string randomNumber = rnd.Next(1000, 9999).ToString() + "-" + rnd.Next(10, 99).ToString();
            string registrationNumber = "2023" + randomNumber;
            return registrationNumber;
        }
    }
}
