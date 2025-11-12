using Entity.Model.Base;
namespace Entity.Model.Security
{
    public class FormModule : BaseModel
    {
        
        public int FormId { get; set; }
        public Form Form { get; set; }
        public int ModuleId { get; set; }
        public Modules Module { get; set; }
    }
}