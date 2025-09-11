using Business.Interfaces;
using Entity.Dtos.Base;
using Entity.Model.Base;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Web.Controllers.Implements
{
    [Route("api/[controller]")]
    public class RolController : GenericController<RolDto, Rol>
    {
        public RolController(IRolBusiness business, ILogger<RolController> logger)
            : base(business, logger) { }

        protected override int GetEntityId(RolDto dto) => dto.Id;
    }
}