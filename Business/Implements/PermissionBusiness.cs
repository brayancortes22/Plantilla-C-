using AutoMapper;
using Business.Interfaces;
using Data.Interfaces;
using Entity.Dtos.Base;
using Entity.Model.Base;
using Microsoft.Extensions.Logging;

namespace Business.Implements
{
    public class PermissionBusiness : BaseBusiness<Permission, PermissionDto>, IPermissionBusiness
    {
        public PermissionBusiness(IPermissionData data, IMapper mapper, ILogger<PermissionBusiness> logger)
            : base(data, mapper, logger) { }
    }
}