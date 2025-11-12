using Business.Interfaces.Anime;
using Entity.Model.Anime;
using Entity.Dtos.Anime;
using Microsoft.AspNetCore.Mvc;
using Web.Controllers.Implements.Base;

namespace Web.Controllers.Anime
{
    [ApiController]
    [Route("api/[controller]")]
     public class UsuarioAnimeController : GenericController<UsuarioAnimeDto, UsuarioAnime>
    {
         public UsuarioAnimeController(IUsuarioAnimeBusiness business, ILogger<UsuarioAnimeController> logger)
            : base(business, logger) { }

        protected override int GetEntityId(UsuarioAnimeDto dto) => dto.Id;
    }
}
