using AutoMapper;
using Entity.Model.Security;
using Entity.Dtos.Security;

namespace Utilities.Mappers.Profiles.Security
{
    public class FormModuleProfile : Profile
    {
        public FormModuleProfile()
        {
            CreateMap<FormModule, FormModuleDto>().ReverseMap();
        }
    }
}