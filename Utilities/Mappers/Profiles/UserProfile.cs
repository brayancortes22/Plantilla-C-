using AutoMapper;
using Entity.Model.Base;
using Entity.Dtos.Base;

namespace Utilities.Mappers.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDto>().ReverseMap();
        }
    }
}