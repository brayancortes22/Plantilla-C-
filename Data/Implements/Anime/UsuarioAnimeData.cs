using Data.Interfaces.Anime;
using Data.Implements.BaseData;
using Entity.Context;
using Entity.Model.Anime;

namespace Data.Implements.Anime
{
    public class UsuarioAnimeData : BaseModelData<UsuarioAnime>, IUsuarioAnimeData
    {
        public UsuarioAnimeData(ApplicationDbContext context) : base(context) { }
    }
}
