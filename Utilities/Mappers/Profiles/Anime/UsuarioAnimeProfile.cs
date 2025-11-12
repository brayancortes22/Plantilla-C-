using AutoMapper;
using Entity.Model.Anime;
using Entity.Dtos.Anime;

namespace Utilities.Mappers.Profiles.Anime
{
    public class UsuarioAnimeProfile : Profile
    {
        public UsuarioAnimeProfile()
        {
            CreateMap<UsuarioAnime, UsuarioAnimeDto>().ReverseMap();
        }
    }
}
