using Entity.Dtos.Base;
namespace Entity.Dtos.Security
{
    public class UserDto : BaseDto
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public bool IsActive { get; set; }
    }
}