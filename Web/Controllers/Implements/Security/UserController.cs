using Business.Interfaces.Security;
using Entity.Dtos.Security;
using Entity.Model.Security;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Web.Controllers.Implements.Security
{
    [Route("api/[controller]")]
    public class UserController : GenericController<UserDto, User>
    {
        public UserController(IUserBusiness business, ILogger<UserController> logger)
            : base(business, logger) { }

        protected override int GetEntityId(UserDto dto) => dto.Id;
    }
}