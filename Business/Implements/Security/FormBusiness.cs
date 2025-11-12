using AutoMapper;
using Microsoft.Extensions.Logging;

using Business.Interfaces.Security;
using Business.Implements.Base;
using Entity.Dtos.Security;
using Entity.Model.Security;
using Data.Interfaces.Security;


namespace Business.Implements.Security
{
    public class FormBusiness : BaseBusiness<Form, FormDto>, IFormBusiness
    {
        public FormBusiness(IFormData data, IMapper mapper, ILogger<FormBusiness> logger)
            : base(data, mapper, logger) { }
    }
}