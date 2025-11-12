using Business.Interfaces.Security;
using Entity.Dtos.Security;
using Entity.Model.Security;
using Web.Controllers.Implements.Base;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Web.Controllers.Implements.Security
{
    [Route("api/[controller]")]
    public class PermissionController : GenericController<PermissionDto, Permission>
    {
        public PermissionController(IPermissionBusiness business, ILogger<PermissionController> logger)
            : base(business, logger) { }

        protected override int GetEntityId(PermissionDto dto) => dto.Id;
    }
}