using AutoMapper;
using Microsoft.Extensions.Logging;

using Business.Implements.Base;
using Data.Interfaces.Anime;
using Entity.Model.Anime;
using Entity.Dtos.Anime;
using Business.Interfaces.Anime;

namespace Business.Implements.Anime
{
    public class UsuarioAnimeBusiness : BaseBusiness<UsuarioAnime, UsuarioAnimeDto>, IUsuarioAnimeBusiness
    {
        public UsuarioAnimeBusiness(IUsuarioAnimeData data, IMapper mapper, ILogger<UsuarioAnimeBusiness> logger)
            : base(data, mapper, logger) { }
    }
}
