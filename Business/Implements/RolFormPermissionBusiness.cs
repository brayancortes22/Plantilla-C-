using AutoMapper;
using Business.Interfaces;
using Data.Interfaces;
using Entity.Dtos.Base;
using Entity.Model.Base;
using Microsoft.Extensions.Logging;

namespace Business.Implements
{
    public class RolFormPermissionBusiness : BaseBusiness<RolFormPermission, RolFormPermissionDto>, IRolFormPermissionBusiness
    {
        public RolFormPermissionBusiness(IRolFormPermissionData data, IMapper mapper, ILogger<RolFormPermissionBusiness> logger)
            : base(data, mapper, logger) { }
    }
}