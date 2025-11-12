using AutoMapper;
using Microsoft.Extensions.Logging;

using Business.Implements.Base;
using Data.Interfaces.Anime;
using Entity.Model.Anime;
using Entity.Dtos.Anime;
using Business.Interfaces.Anime;

namespace Business.Implements.Anime
{
    public class PersonajeVozBusiness : BaseBusiness<PersonajeVoz, PersonajeVozDto>, IPersonajeVozBusiness
    {
        public PersonajeVozBusiness(IPersonajeVozData data, IMapper mapper, ILogger<PersonajeVozBusiness> logger)
            : base(data, mapper, logger) { }
    }
}
