using Business.Interfaces.Security;
using Entity.Dtos.Security;
using Entity.Model.Security;
using Web.Controllers.Implements.Base;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Web.Controllers.Implements.Security
{
    [Route("api/[controller]")]
    public class FormController : GenericController<FormDto, Form>
    {
        public FormController(IFormBusiness business, ILogger<GenericController<FormDto, Form>> logger)
            : base(business, logger) { }

        protected override int GetEntityId(FormDto dto) => dto.Id;
    }
}