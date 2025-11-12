using Business.Interfaces.Anime;
using Entity.Model.Anime;
using Entity.Dtos.Anime;
using Microsoft.AspNetCore.Mvc;
using Web.Controllers.Implements.Base;

namespace Web.Controllers.Anime
{
    [ApiController]
    [Route("api/[controller]")]
     public class ActorVozController : GenericController<ActorVozDto, ActorVoz>
    {
         public ActorVozController(IActorVozBusiness business, ILogger<ActorVozController> logger)
            : base(business, logger) { }

        protected override int GetEntityId(ActorVozDto dto) => dto.Id;
    }
}
