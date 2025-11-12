using Business.Interfaces.Security;
using Entity.Dtos.Security;
using Entity.Model.Security;
using Web.Controllers.Implements.Base;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Web.Controllers.Implements.Security
{
    [Route("api/[controller]")]
    public class RolUserController : GenericController<RolUserDto, RolUser>
    {
        public RolUserController(IRolUserBusiness business, ILogger<RolUserController> logger)
            : base(business, logger) { }

        protected override int GetEntityId(RolUserDto dto) => dto.Id;
    }
}