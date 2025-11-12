using AutoMapper;
using Microsoft.Extensions.Logging;

using Business.Interfaces.Security;
using Business.Implements.Base;
using Entity.Dtos.Security;
using Entity.Model.Security;
using Data.Interfaces.Security;


namespace Business.Implements.Security
{
    public class RolUserBusiness : BaseBusiness<RolUser, RolUserDto>, IRolUserBusiness
    {
        public RolUserBusiness(IRolUserData data, IMapper mapper, ILogger<RolUserBusiness> logger)
            : base(data, mapper, logger) { }
    }
}