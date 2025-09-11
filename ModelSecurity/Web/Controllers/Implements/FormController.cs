using Business.Interfaces;
using Entity.Dtos.Base;
using Entity.Model.Base;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Web.Controllers.Implements
{
    [Route("api/[controller]")]
    public class FormController : GenericController<FormDto, Form>
    {
        public FormController(IFormBusiness business, ILogger<FormController> logger)
            : base(business, logger) { }

        protected override int GetEntityId(FormDto dto) => dto.Id;
    }
}