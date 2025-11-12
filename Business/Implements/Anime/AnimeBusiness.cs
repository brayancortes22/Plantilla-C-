using AutoMapper;
using Microsoft.Extensions.Logging;

using Business.Implements.Base;
using Data.Interfaces.Anime;
using Entity.Model.Anime;
using Entity.Dtos.Anime;
using Business.Interfaces.Anime;

namespace Business.Implements.Anime
{
    public class AnimeBusiness : BaseBusiness<Animes, AnimeDto>, IAnimeBusiness
    {
        public AnimeBusiness(IAnimeData data, IMapper mapper, ILogger<AnimeBusiness> logger)
            : base(data, mapper, logger) { }
    }
}
