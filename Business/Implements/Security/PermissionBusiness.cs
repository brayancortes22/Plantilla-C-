using AutoMapper;
using Microsoft.Extensions.Logging;

using Business.Interfaces.Security;
using Business.Implements.Base;
using Entity.Dtos.Security;
using Entity.Model.Security;
using Data.Interfaces.Security;


namespace Business.Implements.Security
{
    public class PermissionBusiness : BaseBusiness<Permission, PermissionDto>, IPermissionBusiness
    {
        public PermissionBusiness(IPermissionData data, IMapper mapper, ILogger<PermissionBusiness> logger)
            : base(data, mapper, logger) { }
    }
}