namespace Entity.Dtos.Base
{
    public class RolUserDto : BaseDto
    {
        public int UserId { get; set; }
        public int RolId { get; set; }
        public DateTime AssignedAt { get; set; }
    }
}