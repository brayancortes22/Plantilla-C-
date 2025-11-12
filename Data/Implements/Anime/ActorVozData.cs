using Data.Interfaces.Anime;
using Data.Implements.BaseData;
using Entity.Context;
using Entity.Model.Anime;

namespace Data.Implements.Anime
{
    public class ActorVozData : BaseModelData<ActorVoz>, IActorVozData
    {
        public ActorVozData(ApplicationDbContext context) : base(context) { }
    }
}
