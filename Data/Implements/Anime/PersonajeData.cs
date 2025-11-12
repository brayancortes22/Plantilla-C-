using Data.Interfaces.Anime;
using Data.Implements.BaseData;
using Entity.Context;
using Entity.Model.Anime;

namespace Data.Implements.Anime
{
    public class PersonajeData : BaseModelData<Personaje>, IPersonajeData
    {
        public PersonajeData(ApplicationDbContext context) : base(context) { }
    }
}
