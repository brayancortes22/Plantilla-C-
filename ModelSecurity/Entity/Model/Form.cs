namespace Entity.Model.Base
{
    public class Form : BaseModel
    {
        public string Name { get; set; }
        public string Url { get; set; }             // Nuevo
        public string Icon { get; set; }            // Nuevo
        public ICollection<FormModule> FormModules { get; set; }
        public ICollection<RolFormPermission> RolFormPermissions { get; set; }
    }
}