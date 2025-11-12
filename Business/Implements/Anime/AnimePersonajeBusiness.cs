using AutoMapper;
using Microsoft.Extensions.Logging;

using Business.Implements.Base;
using Data.Interfaces.Anime;
using Entity.Model.Anime;
using Entity.Dtos.Anime;
using Business.Interfaces.Anime;

namespace Business.Implements.Anime
{
    public class AnimePersonajeBusiness : BaseBusiness<AnimePersonaje, AnimePersonajeDto>, IAnimePersonajeBusiness
    {
        public AnimePersonajeBusiness(IAnimePersonajeData data, IMapper mapper, ILogger<AnimePersonajeBusiness> logger)
            : base(data, mapper, logger) { }
    }
}
