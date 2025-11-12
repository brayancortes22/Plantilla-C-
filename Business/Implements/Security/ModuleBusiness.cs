using AutoMapper;
using Microsoft.Extensions.Logging;

using Business.Interfaces.Security;
using Business.Implements.Base;
using Entity.Dtos.Security;
using Entity.Model.Security;
using Data.Interfaces.Security;


namespace Business.Implements.Security
{
    public class ModuleBusiness : BaseBusiness<Modules, ModuleDto>, IModuleBusiness
    {
        public ModuleBusiness(IModuleData data, IMapper mapper, ILogger<ModuleBusiness> logger)
            : base(data, mapper, logger) { }
    }
}