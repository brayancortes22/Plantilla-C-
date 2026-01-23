using AutoMapper;
using Business.Interfaces;
using Data.Interfaces;
using Entity.Dtos.Base;
using Entity.Model.Base;
using Microsoft.Extensions.Logging;

namespace Business.Implements
{
    public class RolBusiness : BaseBusiness<Rol, RolDto>, IRolBusiness
    {
        public RolBusiness(IRolData data, IMapper mapper, ILogger<RolBusiness> logger)
            : base(data, mapper, logger) { }
    }
}