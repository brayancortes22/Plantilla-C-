using Entity.Model.Base;
namespace Entity.Model.Security
{
    public class RolUser : BaseModel
    {
        
        public int UserId { get; set; }
        public User User { get; set; }
        public int RolId { get; set; }
        public Rol Rol { get; set; }
    }
}