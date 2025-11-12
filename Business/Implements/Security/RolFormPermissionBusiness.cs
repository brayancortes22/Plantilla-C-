using AutoMapper;
using Microsoft.Extensions.Logging;

using Business.Interfaces.Security;
using Business.Implements.Base;
using Entity.Dtos.Security;
using Entity.Model.Security;
using Data.Interfaces.Security;


namespace Business.Implements.Security
{
    public class RolFormPermissionBusiness : BaseBusiness<RolFormPermission, RolFormPermissionDto>, IRolFormPermissionBusiness
    {
        public RolFormPermissionBusiness(IRolFormPermissionData data, IMapper mapper, ILogger<RolFormPermissionBusiness> logger)
            : base(data, mapper, logger) { }
    }
}