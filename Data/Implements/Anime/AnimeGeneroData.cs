using Data.Interfaces.Anime;
using Data.Implements.BaseData;
using Entity.Context;
using Entity.Model.Anime;

namespace Data.Implements.Anime
{
    public class AnimeGeneroData : BaseModelData<AnimeGenero>, IAnimeGeneroData
    {
        public AnimeGeneroData(ApplicationDbContext context) : base(context) { }
    }
}
