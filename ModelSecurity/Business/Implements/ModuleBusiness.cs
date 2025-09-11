using AutoMapper;
using Business.Interfaces;
using Data.Interfaces;
using Entity.Dtos.Base;
using Entity.Model.Base;
using Microsoft.Extensions.Logging;

namespace Business.Implements
{
    public class ModuleBusiness : BaseBusiness<Module, ModuleDto>, IModuleBusiness
    {
        public ModuleBusiness(IModuleData data, IMapper mapper, ILogger<ModuleBusiness> logger)
            : base(data, mapper, logger) { }
    }
}