using AutoMapper;
using Entity.Model.Security;
using Entity.Dtos.Security;

namespace Utilities.Mappers.Profiles.Security
{
    public class ModuleProfile : Profile
    {
        public ModuleProfile()
        {
            CreateMap<Modules, ModuleDto>().ReverseMap();
        }
    }
}