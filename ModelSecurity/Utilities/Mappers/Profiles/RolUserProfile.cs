using AutoMapper;
using Entity.Model.Base;
using Entity.Dtos.Base;

namespace Utilities.Mappers.Profiles
{
    public class RolUserProfile : Profile
    {
        public RolUserProfile()
        {
            CreateMap<RolUser, RolUserDto>().ReverseMap();
        }
    }
}