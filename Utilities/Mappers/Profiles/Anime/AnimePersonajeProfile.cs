using AutoMapper;
using Entity.Model.Anime;
using Entity.Dtos.Anime;

namespace Utilities.Mappers.Profiles.Anime
{
    public class AnimePersonajeProfile : Profile
    {
        public AnimePersonajeProfile()
        {
            CreateMap<AnimePersonaje, AnimePersonajeDto>().ReverseMap();
        }
    }
}
