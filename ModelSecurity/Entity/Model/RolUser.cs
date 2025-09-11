namespace Entity.Model.Base
{
    public class RolUser : BaseModel
    {
        
        public int UserId { get; set; }
        public User User { get; set; }
        public int RolId { get; set; }
        public Rol Rol { get; set; }
    }
}