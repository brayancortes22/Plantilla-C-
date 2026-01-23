using AutoMapper;
using Entity.Model.Base;
using Entity.Dtos.Base;

namespace Utilities.Mappers.Profiles
{
    public class FormModuleProfile : Profile
    {
        public FormModuleProfile()
        {
            CreateMap<FormModule, FormModuleDto>().ReverseMap();
        }
    }
}