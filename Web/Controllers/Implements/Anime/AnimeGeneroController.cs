using Business.Interfaces.Anime;
using Entity.Model.Anime;
using Entity.Dtos.Anime;
using Microsoft.AspNetCore.Mvc;
using Web.Controllers.Implements.Base;

namespace Web.Controllers.Anime
{
    [ApiController]
    [Route("api/[controller]")]
    public class AnimeGeneroController : GenericController<AnimeGeneroDto, AnimeGenero>
    {
         public AnimeGeneroController(IAnimeGeneroBusiness business, ILogger<AnimeGeneroController> logger)
            : base(business, logger) { }

        protected override int GetEntityId(AnimeGeneroDto dto) => dto.Id;
    }
}
