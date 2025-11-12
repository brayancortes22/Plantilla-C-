using Data.Interfaces.Anime;
using Data.Implements.BaseData;
using Entity.Context;
using Entity.Model.Anime;

namespace Data.Implements.Anime
{
    public class AnimePersonajeData : BaseModelData<AnimePersonaje>, IAnimePersonajeData
    {
        public AnimePersonajeData(ApplicationDbContext context) : base(context) { }
    }
}
