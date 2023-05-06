using AutoMapper;
using userRole.Data.Dtos;
using userRole.Models;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<User, ReadUserDto>();
        CreateMap<ReadUserDto, User>();
        CreateMap<User, CreateUserDto>();
        CreateMap<CreateUserDto, User>();
        CreateMap<UpdateUserDto, User>();
    }
}