using Business.Interfaces;
using Entity.Dtos.Base;
using Entity.Model.Base;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Web.Controllers.Implements
{
    [Route("api/[controller]")]
    public class UserController : GenericController<UserDto, User>
    {
        public UserController(IUserBusiness business, ILogger<UserController> logger)
            : base(business, logger) { }

        protected override int GetEntityId(UserDto dto) => dto.Id;
    }
}