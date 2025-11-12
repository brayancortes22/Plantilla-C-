using AutoMapper;
using Entity.Model.Security;
using Entity.Dtos.Security;

namespace Utilities.Mappers.Profiles.Security
{
    public class RolFormPermissionProfile : Profile
    {
        public RolFormPermissionProfile()
        {
            CreateMap<RolFormPermission, RolFormPermissionDto>().ReverseMap();
        }
    }
}