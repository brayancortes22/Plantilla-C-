using AutoMapper;
using Microsoft.Extensions.Logging;

using Business.Interfaces.Security;
using Business.Implements.Base;
using Entity.Dtos.Security;
using Entity.Model.Security;
using Data.Interfaces.Security;


namespace Business.Implements.Security
{
    public class RolBusiness : BaseBusiness<Rol, RolDto>, IRolBusiness
    {
        public RolBusiness(IRolData data, IMapper mapper, ILogger<RolBusiness> logger)
            : base(data, mapper, logger) { }
    }
}