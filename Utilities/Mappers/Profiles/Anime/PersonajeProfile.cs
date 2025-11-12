using AutoMapper;
using Entity.Model.Anime;
using Entity.Dtos.Anime;

namespace Utilities.Mappers.Profiles.Anime
{
    public class PersonajeProfile : Profile
    {
        public PersonajeProfile()
        {
            CreateMap<Personaje, PersonajeDto>().ReverseMap();
        }
    }
}
