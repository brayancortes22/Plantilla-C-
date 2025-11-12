using Entity.Model.Base;
namespace Entity.Model.Security
{
    public class Modules : BaseModel
    {
        public string Name { get; set; }
        public string Description { get; set; }     // Nuevo
        public int Order { get; set; }              // Nuevo
        public ICollection<FormModule> FormModules { get; set; }
    }
}