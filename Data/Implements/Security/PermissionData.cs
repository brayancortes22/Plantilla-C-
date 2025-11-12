
using Entity.Context;

using Data.Implements.BaseData;
using Data.Interfaces.Security;
using Entity.Model.Security;

namespace Data.Implements.Security
{
    public class PermissionData : BaseModelData<Permission>, IPermissionData
    {
        public PermissionData(ApplicationDbContext context) : base(context) { }
    }
}