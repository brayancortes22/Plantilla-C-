
using Entity.Context;

using Data.Implements.BaseData;
using Data.Interfaces.Security;
using Entity.Model.Security;

namespace Data.Implements.Security
{
    public class RolUserData : BaseModelData<RolUser>, IRolUserData
    {
        public RolUserData(ApplicationDbContext context) : base(context) { }
    }
}