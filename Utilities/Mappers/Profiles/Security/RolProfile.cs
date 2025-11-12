using AutoMapper;
using Entity.Model.Security;
using Entity.Dtos.Security;

namespace Utilities.Mappers.Profiles.Security
{
    public class RolProfile : Profile
    {
        public RolProfile()
        {
            CreateMap<Rol, RolDto>().ReverseMap();
        }
    }
}