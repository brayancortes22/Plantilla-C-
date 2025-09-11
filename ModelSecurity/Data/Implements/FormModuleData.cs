using Data.Interfaces;
using Entity.Context;
using Entity.Model.Base;

namespace Data.Implements
{
    public class FormModuleData : BaseData.BaseModelData<FormModule>, IFormModuleData
    {
        public FormModuleData(ApplicationDbContext context) : base(context) { }
    }
}