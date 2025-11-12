using AutoMapper;
using Entity.Model.Anime;
using Entity.Dtos.Anime;

namespace Utilities.Mappers.Profiles.Anime
{
    public class PersonajeVozProfile : Profile
    {
        public PersonajeVozProfile()
        {
            CreateMap<PersonajeVoz, PersonajeVozDto>().ReverseMap();
        }
    }
}
