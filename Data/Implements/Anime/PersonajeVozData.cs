using Data.Interfaces.Anime;
using Data.Implements.BaseData;
using Entity.Context;
using Entity.Model.Anime;

namespace Data.Implements.Anime
{
    public class PersonajeVozData : BaseModelData<PersonajeVoz>, IPersonajeVozData
    {
        public PersonajeVozData(ApplicationDbContext context) : base(context) { }
    }
}
