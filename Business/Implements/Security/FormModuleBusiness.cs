using AutoMapper;
using Microsoft.Extensions.Logging;

using Business.Interfaces.Security;
using Business.Implements.Base;
using Entity.Dtos.Security;
using Entity.Model.Security;
using Data.Interfaces.Security;


namespace Business.Implements.Security
{
    public class FormModuleBusiness : BaseBusiness<FormModule, FormModuleDto>, IFormModuleBusiness
    {
        public FormModuleBusiness(IFormModuleData data, IMapper mapper, ILogger<FormModuleBusiness> logger)
            : base(data, mapper, logger) { }
    }
}