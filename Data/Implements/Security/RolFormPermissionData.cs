
using Entity.Context;

using Data.Implements.BaseData;
using Data.Interfaces.Security;
using Entity.Model.Security;

namespace Data.Implements.Security
{
    public class RolFormPermissionData : BaseModelData<RolFormPermission>, IRolFormPermissionData
    {
        public RolFormPermissionData(ApplicationDbContext context) : base(context) { }
    }
}