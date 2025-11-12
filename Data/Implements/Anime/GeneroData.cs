using Data.Interfaces.Anime;
using Data.Implements.BaseData;
using Entity.Context;
using Entity.Model.Anime;

namespace Data.Implements.Anime
{
    public class GeneroData : BaseModelData<Genero>, IGeneroData
    {
        public GeneroData(ApplicationDbContext context) : base(context) { }
    }
}
