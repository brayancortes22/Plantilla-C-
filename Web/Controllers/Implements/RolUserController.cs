using Business.Interfaces;
using Entity.Dtos.Base;
using Entity.Model.Base;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Web.Controllers.Implements
{
    [Route("api/[controller]")]
    public class RolUserController : GenericController<RolUserDto, RolUser>
    {
        public RolUserController(IRolUserBusiness business, ILogger<RolUserController> logger)
            : base(business, logger) { }

        protected override int GetEntityId(RolUserDto dto) => dto.Id;
    }
}