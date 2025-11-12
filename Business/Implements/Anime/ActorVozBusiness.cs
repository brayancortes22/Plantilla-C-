using AutoMapper;
using Microsoft.Extensions.Logging;

using Business.Implements.Base;
using Data.Interfaces.Anime;
using Entity.Model.Anime;
using Entity.Dtos.Anime;
using Business.Interfaces.Anime;

namespace Business.Implements.Anime
{
    public class ActorVozBusiness : BaseBusiness<ActorVoz, ActorVozDto>, IActorVozBusiness
    {
        public ActorVozBusiness(IActorVozData data, IMapper mapper, ILogger<ActorVozBusiness> logger)
            : base(data, mapper, logger) { }
    }
}
