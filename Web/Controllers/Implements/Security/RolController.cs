using Business.Interfaces.Security;
using Entity.Dtos.Security;
using Entity.Model.Security;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Web.Controllers.Implements.Security
{
    [Route("api/[controller]")]
    public class RolController : GenericController<RolDto, Rol>
    {
        public RolController(IRolBusiness business, ILogger<RolController> logger)
            : base(business, logger) { }

        protected override int GetEntityId(RolDto dto) => dto.Id;
    }
}