using AutoMapper;
using Entity.Model.Anime;
using Entity.Dtos.Anime;

namespace Utilities.Mappers.Profiles.Anime
{
    public class AnimeGeneroProfile : Profile
    {
        public AnimeGeneroProfile()
        {
            CreateMap<AnimeGenero, AnimeGeneroDto>().ReverseMap();
        }
    }
}
