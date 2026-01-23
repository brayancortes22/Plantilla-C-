using Business.Interfaces;
using Entity.Dtos.Base;
using Entity.Model.Base;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Web.Controllers.Implements
{
    [Route("api/[controller]")]
    public class RolFormPermissionController : GenericController<RolFormPermissionDto, RolFormPermission>
    {
        public RolFormPermissionController(IRolFormPermissionBusiness business, ILogger<RolFormPermissionController> logger)
            : base(business, logger) { }

        protected override int GetEntityId(RolFormPermissionDto dto) => dto.Id;
    }
}