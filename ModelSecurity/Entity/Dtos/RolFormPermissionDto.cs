namespace Entity.Dtos.Base
{
    public class RolFormPermissionDto : BaseDto
    {
        
        public int RolId { get; set; }
        public int FormId { get; set; }
        public int PermissionId { get; set; }
    }
}