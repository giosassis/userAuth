using AutoMapper;
using userRole.Models;
using userRole.Data.Dtos;

namespace userRole.Profiles
{
    public class PermissionProfile : Profile
    {
        public PermissionProfile()
        {
            CreateMap<Permission, ReadPermissionDto>();
        }
    }
}