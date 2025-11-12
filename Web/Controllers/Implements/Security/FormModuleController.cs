using Business.Interfaces.Security;
using Entity.Dtos.Security;
using Entity.Model.Security;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Web.Controllers.Implements.Security
{
    [Route("api/[controller]")]
    public class FormModuleController : GenericController<FormModuleDto, FormModule>
    {
        public FormModuleController(IFormModuleBusiness business, ILogger<FormModuleController> logger)
            : base(business, logger) { }

        protected override int GetEntityId(FormModuleDto dto) => dto.Id;
    }
}