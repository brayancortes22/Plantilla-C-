using Data.Interfaces.Anime;
using Data.Implements.BaseData;
using Entity.Context;
using Entity.Model.Anime;

namespace Data.Implements.Anime
{
    public class AnimeData : BaseModelData<Animes>, IAnimeData
    {
        public AnimeData(ApplicationDbContext context) : base(context) { }
    }
}
