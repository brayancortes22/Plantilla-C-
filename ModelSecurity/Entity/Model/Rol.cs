namespace Entity.Model.Base
{
    public class Rol : BaseModel
    {
        public string Name { get; set; }
        public string Description { get; set; }     // Nuevo
        public bool IsSystem { get; set; } = false; // Nuevo
        public ICollection<RolUser> RolUsers { get; set; }
        public ICollection<RolFormPermission> RolFormPermissions { get; set; }
    }
}