using Business.Interfaces.Anime;
using Entity.Model.Anime;
using Entity.Dtos.Anime;
using Microsoft.AspNetCore.Mvc;
using Web.Controllers.Implements.Base;

namespace Web.Controllers.Anime
{
    [ApiController]
    [Route("api/[controller]")]
     public class PersonajeVozController : GenericController<PersonajeVozDto, PersonajeVoz>
    {
         public PersonajeVozController(IPersonajeVozBusiness business, ILogger<PersonajeVozController> logger)
            : base(business, logger) { }

        protected override int GetEntityId(PersonajeVozDto dto) => dto.Id;
    }
}
