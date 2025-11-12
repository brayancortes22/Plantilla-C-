using AutoMapper;
using Entity.Model.Anime;
using Entity.Dtos.Anime;

namespace Utilities.Mappers.Profiles.Anime
{
    public class AnimeProfile : Profile
    {
        public AnimeProfile()
        {
            CreateMap<Animes, AnimeDto>().ReverseMap();
        }
    }
}
