using AutoMapper;
using Entity.Model.Security;
using Entity.Dtos.Security;

namespace Utilities.Mappers.Profiles.Security
{
    public class RolUserProfile : Profile
    {
        public RolUserProfile()
        {
            CreateMap<RolUser, RolUserDto>().ReverseMap();
        }
    }
}