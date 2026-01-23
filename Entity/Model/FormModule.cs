namespace Entity.Model.Base
{
    public class FormModule : BaseModel
    {
        
        public int FormId { get; set; }
        public Form Form { get; set; }
        public int ModuleId { get; set; }
        public Module Module { get; set; }
    }
}