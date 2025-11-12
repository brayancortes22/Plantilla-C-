using Data.Interfaces.Anime;
using Data.Implements.BaseData;
using Entity.Context;
using Entity.Model.Anime;

namespace Data.Implements.Anime
{
    public class EstudioData : BaseModelData<Estudio>, IEstudioData
    {
        public EstudioData(ApplicationDbContext context) : base(context) { }
    }
}
