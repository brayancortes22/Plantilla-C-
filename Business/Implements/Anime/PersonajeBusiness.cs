using AutoMapper;
using Microsoft.Extensions.Logging;

using Business.Implements.Base;
using Data.Interfaces.Anime;
using Entity.Model.Anime;
using Entity.Dtos.Anime;
using Business.Interfaces.Anime;

namespace Business.Implements.Anime
{
    public class PersonajeBusiness : BaseBusiness<Personaje, PersonajeDto>, IPersonajeBusiness
    {
        public PersonajeBusiness(IPersonajeData data, IMapper mapper, ILogger<PersonajeBusiness> logger)
            : base(data, mapper, logger) { }
    }
}
