using AutoMapper;
using Microsoft.Extensions.Logging;

using Business.Implements.Base;
using Data.Interfaces.Anime;
using Entity.Model.Anime;
using Entity.Dtos.Anime;
using Business.Interfaces.Anime;

namespace Business.Implements.Anime
{
    public class GeneroBusiness : BaseBusiness<Genero, GeneroDto>, IGeneroBusiness
    {
        public GeneroBusiness(IGeneroData data, IMapper mapper, ILogger<GeneroBusiness> logger)
            : base(data, mapper, logger) { }
    }
}
