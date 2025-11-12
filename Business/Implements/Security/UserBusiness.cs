using AutoMapper;
using Microsoft.Extensions.Logging;

using Business.Interfaces.Security;
using Business.Implements.Base;
using Entity.Dtos.Security;
using Entity.Model.Security;
using Data.Interfaces.Security;

namespace Business.Implements.Security
{
    public class UserBusiness : BaseBusiness<User, UserDto>, IUserBusiness
    {
        public UserBusiness(IUserData data, IMapper mapper, ILogger<UserBusiness> logger)
            : base(data, mapper, logger) { }
        // Métodos adicionales específicos de User
    }
}