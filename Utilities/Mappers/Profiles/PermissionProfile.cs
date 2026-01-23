using AutoMapper;
using Entity.Model.Base;
using Entity.Dtos.Base;

namespace Utilities.Mappers.Profiles
{
    public class PermissionProfile : Profile
    {
        public PermissionProfile()
        {
            CreateMap<Permission, PermissionDto>().ReverseMap();
        }
    }
}