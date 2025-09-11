using Data.Interfaces;
using Entity.Context;
using Entity.Model.Base;

namespace Data.Implements
{
    public class FormData : BaseData.BaseModelData<Form>, IFormData
    {
        public FormData(ApplicationDbContext context) : base(context) { }
    }
}