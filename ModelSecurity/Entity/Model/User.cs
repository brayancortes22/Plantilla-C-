namespace Entity.Model.Base
{
    public class User : BaseModel
    {
        public string UserName { get; set; }
        public string Email { get; set; }           // Nuevo
        public string PasswordHash { get; set; }    // Nuevo
        public bool IsActive { get; set; } = true;  // Nuevo
        public ICollection<RolUser> RolUsers { get; set; }
    }
}