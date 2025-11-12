using Business.Interfaces.Anime;
using Entity.Model.Anime;
using Entity.Dtos.Anime;
using Microsoft.AspNetCore.Mvc;
using Web.Controllers.Implements.Base;

namespace Web.Controllers.Anime
{
    [ApiController]
    [Route("api/[controller]")]
    public class GeneroController : GenericController<GeneroDto, Genero>
    {
         public GeneroController(IGeneroBusiness business, ILogger<GeneroController> logger)
            : base(business, logger) { }

        protected override int GetEntityId(GeneroDto dto) => dto.Id;
    }
}
