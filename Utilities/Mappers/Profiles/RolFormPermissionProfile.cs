using AutoMapper;
using Entity.Model.Base;
using Entity.Dtos.Base;

namespace Utilities.Mappers.Profiles
{
    public class RolFormPermissionProfile : Profile
    {
        public RolFormPermissionProfile()
        {
            CreateMap<RolFormPermission, RolFormPermissionDto>().ReverseMap();
        }
    }
}