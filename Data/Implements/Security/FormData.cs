
using Entity.Context;

using Data.Implements.BaseData;
using Data.Interfaces.Security;
using Entity.Model.Security;

namespace Data.Implements.Security
{
    public class FormData : BaseModelData<Form>, IFormData
    {
        public FormData(ApplicationDbContext context) : base(context) { }
    }
}