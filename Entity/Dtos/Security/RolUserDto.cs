using Entity.Dtos.Base;
namespace Entity.Dtos.Security
{
    public class RolUserDto : BaseDto
    {
        public int UserId { get; set; }
        public int RolId { get; set; }
        public DateTime AssignedAt { get; set; }
    }
}