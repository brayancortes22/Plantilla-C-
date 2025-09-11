namespace Entity.Model.Base
{
    public class Permission : BaseModel
    {
        public string Name { get; set; }
        public string Description { get; set; }     // Nuevo
        public ICollection<RolFormPermission> RolFormPermissions { get; set; }
    }
}