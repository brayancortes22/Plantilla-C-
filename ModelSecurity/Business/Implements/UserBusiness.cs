using AutoMapper;
using Business.Interfaces;
using Data.Interfaces;
using Entity.Dtos.Base;
using Entity.Model.Base;
using Microsoft.Extensions.Logging;

namespace Business.Implements
{
    public class UserBusiness : BaseBusiness<User, UserDto>, IUserBusiness
    {
        public UserBusiness(IUserData data, IMapper mapper, ILogger<UserBusiness> logger)
            : base(data, mapper, logger) { }
        // Métodos adicionales específicos de User
    }
}