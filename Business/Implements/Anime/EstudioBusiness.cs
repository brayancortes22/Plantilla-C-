using AutoMapper;
using Microsoft.Extensions.Logging;

using Business.Implements.Base;
using Data.Interfaces.Anime;
using Entity.Model.Anime;
using Entity.Dtos.Anime;
using Business.Interfaces.Anime;

namespace Business.Implements.Anime
{
    public class EstudioBusiness : BaseBusiness<Estudio, EstudioDto>, IEstudioBusiness
    {
        public EstudioBusiness(IEstudioData data, IMapper mapper, ILogger<EstudioBusiness> logger)
            : base(data, mapper, logger) { }
    }
}
