using Business.Interfaces.Security;
using Entity.Dtos.Security;
using Entity.Model.Security;
using Web.Controllers.Implements.Base;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Web.Controllers.Implements.Security
{
    [Route("api/[controller]")]
    public class ModuleController : GenericController<ModuleDto, Modules>
    {
        public ModuleController(IModuleBusiness business, ILogger<ModuleController> logger)
            : base(business, logger) { }

        protected override int GetEntityId(ModuleDto dto) => dto.Id;
    }
}