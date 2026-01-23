using Data.Interfaces;
using Entity.Context;
using Entity.Model.Base;

namespace Data.Implements
{
    public class PermissionData : BaseData.BaseModelData<Permission>, IPermissionData
    {
        public PermissionData(ApplicationDbContext context) : base(context) { }
    }
}