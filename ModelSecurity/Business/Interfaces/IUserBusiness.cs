using Entity.Model.Base;
using Entity.Dtos.Base;

namespace Business.Interfaces
{
    public interface IUserBusiness : IBaseBusiness<User, UserDto>
    {
        // Métodos adicionales específicos de User si se requieren
    }
}