using AutoMapper;
using Entity.Model.Base;
using Entity.Dtos.Base;

namespace Utilities.Mappers.Profiles
{
    public class ModuleProfile : Profile
    {
        public ModuleProfile()
        {
            CreateMap<Module, ModuleDto>().ReverseMap();
        }
    }
}