using AutoMapper;
using Entity.Model.Security;
using Entity.Dtos.Security;

namespace Utilities.Mappers.Profiles.Security
{
    public class PermissionProfile : Profile
    {
        public PermissionProfile()
        {
            CreateMap<Permission, PermissionDto>().ReverseMap();
        }
    }
}