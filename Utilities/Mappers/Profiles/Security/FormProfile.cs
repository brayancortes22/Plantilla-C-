using AutoMapper;
using Entity.Model.Security;
using Entity.Dtos.Security;

namespace Utilities.Mappers.Profiles.Security
{
    public class FormProfile : Profile
    {
        public FormProfile()
        {
            CreateMap<Form, FormDto>().ReverseMap();
        }
    }
}