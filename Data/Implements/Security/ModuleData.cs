
using Entity.Context;

using Data.Implements.BaseData;
using Data.Interfaces.Security;
using Entity.Model.Security;

namespace Data.Implements.Security
{
    public class ModuleData : BaseModelData<Modules>, IModuleData
    {
        public ModuleData(ApplicationDbContext context) : base(context) { }
    }
}