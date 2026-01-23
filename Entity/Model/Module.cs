namespace Entity.Model.Base
{
    public class Module : BaseModel
    {
        public string Name { get; set; }
        public string Description { get; set; }     // Nuevo
        public int Order { get; set; }              // Nuevo
        public ICollection<FormModule> FormModules { get; set; }
    }
}