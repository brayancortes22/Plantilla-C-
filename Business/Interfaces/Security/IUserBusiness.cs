using Business.Interfaces.Base;
using Entity.Model.Security;
using Entity.Dtos.Security;

namespace Business.Interfaces.Security
{
    public interface IUserBusiness : IBaseBusiness<User, UserDto>
    {
        // Métodos adicionales específicos de User si se requieren
    }
}