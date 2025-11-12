
using Entity.Context;

using Data.Implements.BaseData;
using Data.Interfaces.Security;
using Entity.Model.Security;

namespace Data.Implements.Security
{
    public class RolData : BaseModelData<Rol>, IRolData
    {
        public RolData(ApplicationDbContext context) : base(context) { }
    }
}