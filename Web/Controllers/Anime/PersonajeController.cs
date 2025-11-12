using Business.Interfaces.Anime;
using Entity.Model.Anime;
using Entity.Dtos.Anime;
using Microsoft.AspNetCore.Mvc;
using Web.Controllers.Implements.Base;

namespace Web.Controllers.Anime
{
    [ApiController]
    [Route("api/[controller]")]
     public class PersonajeController : GenericController<PersonajeDto, Personaje>
    {
         public PersonajeController(IPersonajeBusiness business, ILogger<PersonajeController> logger)
            : base(business, logger) { }

        protected override int GetEntityId(PersonajeDto dto) => dto.Id;
    }
}
