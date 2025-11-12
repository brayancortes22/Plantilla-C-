using AutoMapper;
using Microsoft.Extensions.Logging;

using Business.Implements.Base;
using Data.Interfaces.Anime;
using Entity.Model.Anime;
using Entity.Dtos.Anime;
using Business.Interfaces.Anime;

namespace Business.Implements.Anime
{
    public class AnimeGeneroBusiness : BaseBusiness<AnimeGenero, AnimeGeneroDto>, IAnimeGeneroBusiness
    {
        public AnimeGeneroBusiness(IAnimeGeneroData data, IMapper mapper, ILogger<AnimeGeneroBusiness> logger)
            : base(data, mapper, logger) { }
    }
}
