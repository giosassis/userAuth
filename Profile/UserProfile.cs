using AutoMapper;
using userRole.Data.Dtos;
using userRole.Models;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<Users, ReadUserDto>();
        CreateMap<ReadUserDto, Users>();
        CreateMap<Users, CreateUserDto>();
        CreateMap<CreateUserDto, Users>();
        CreateMap<UpdateUserDto, Users>();
    }
}