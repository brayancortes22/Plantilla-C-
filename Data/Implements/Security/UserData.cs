
using Entity.Context;

using Data.Implements.BaseData;
using Data.Interfaces.Security;
using Entity.Model.Security;

namespace Data.Implements.Security
{
    public class UserData : BaseModelData<User>, IUserData
    {
        public UserData(ApplicationDbContext context) : base(context) { }
        // Métodos adicionales específicos de User
    }
}