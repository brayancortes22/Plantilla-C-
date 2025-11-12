using Business.Interfaces.Anime;
using Entity.Model.Anime;
using Entity.Dtos.Anime;
using Microsoft.AspNetCore.Mvc;
using Web.Controllers.Implements.Base;

namespace Web.Controllers.Anime
{
    [ApiController]
    [Route("api/[controller]")]
    public class AnimePersonajeController : GenericController<AnimePersonajeDto, AnimePersonaje>
    {
         public AnimePersonajeController(IAnimePersonajeBusiness business, ILogger<AnimePersonajeController> logger)
            : base(business, logger) { }

        protected override int GetEntityId(AnimePersonajeDto dto) => dto.Id;
    }
}
