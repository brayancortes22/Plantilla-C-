using Data.Interfaces;
using Entity.Context;
using Entity.Model.Base;

namespace Data.Implements
{
    public class RolUserData : BaseData.BaseModelData<RolUser>, IRolUserData
    {
        public RolUserData(ApplicationDbContext context) : base(context) { }
    }
}