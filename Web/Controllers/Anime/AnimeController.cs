using Business.Interfaces.Anime;
using Entity.Model.Anime;
using Entity.Dtos.Anime;
using Microsoft.AspNetCore.Mvc;
using Web.Controllers.Implements.Base;

namespace Web.Controllers.Anime
{
    [ApiController]
    [Route("api/[controller]")]
     public class AnimeController : GenericController<AnimeDto, Animes>
    {
         public AnimeController(IAnimeBusiness business, ILogger<AnimeController> logger)
            : base(business, logger) { }

        protected override int GetEntityId(AnimeDto dto) => dto.Id;
    }
}
