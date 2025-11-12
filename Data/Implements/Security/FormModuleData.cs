
using Entity.Context;

using Data.Implements.BaseData;
using Data.Interfaces.Security;
using Entity.Model.Security;

namespace Data.Implements.Security
{
    public class FormModuleData : BaseModelData<FormModule>, IFormModuleData
    {
        public FormModuleData(ApplicationDbContext context) : base(context) { }
    }
}