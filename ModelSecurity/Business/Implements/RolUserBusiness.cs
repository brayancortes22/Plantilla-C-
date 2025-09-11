using AutoMapper;
using Business.Interfaces;
using Data.Interfaces;
using Entity.Dtos.Base;
using Entity.Model.Base;
using Microsoft.Extensions.Logging;

namespace Business.Implements
{
    public class RolUserBusiness : BaseBusiness<RolUser, RolUserDto>, IRolUserBusiness
    {
        public RolUserBusiness(IRolUserData data, IMapper mapper, ILogger<RolUserBusiness> logger)
            : base(data, mapper, logger) { }
    }
}