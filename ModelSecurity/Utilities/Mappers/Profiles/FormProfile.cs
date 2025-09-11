using AutoMapper;
using Entity.Model.Base;
using Entity.Dtos.Base;

namespace Utilities.Mappers.Profiles
{
    public class FormProfile : Profile
    {
        public FormProfile()
        {
            CreateMap<Form, FormDto>().ReverseMap();
        }
    }
}