using Business.Interfaces.Security;
using Entity.Dtos.Security;
using Entity.Model.Security;
using Web.Controllers.Implements.Base;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Web.Controllers.Implements.Security
{
    [Route("api/[controller]")]
    public class RolFormPermissionController : GenericController<RolFormPermissionDto, RolFormPermission>
    {
        public RolFormPermissionController(IRolFormPermissionBusiness business, ILogger<RolFormPermissionController> logger)
            : base(business, logger) { }

        protected override int GetEntityId(RolFormPermissionDto dto) => dto.Id;
    }
}