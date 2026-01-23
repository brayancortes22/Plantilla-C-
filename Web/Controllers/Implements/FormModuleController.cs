using Business.Interfaces;
using Entity.Dtos.Base;
using Entity.Model.Base;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Web.Controllers.Implements
{
    [Route("api/[controller]")]
    public class FormModuleController : GenericController<FormModuleDto, FormModule>
    {
        public FormModuleController(IFormModuleBusiness business, ILogger<FormModuleController> logger)
            : base(business, logger) { }

        protected override int GetEntityId(FormModuleDto dto) => dto.Id;
    }
}