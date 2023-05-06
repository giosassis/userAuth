using AutoMapper;
using userRole.Data.Dtos;
using userRole.Models;

public class PermissionProfile : Profile
{
    public PermissionProfile()
    {
        CreateMap<Permission, ReadPermissionDto>(); ;
    }
}
