using Entity.Dtos.Base;
namespace Entity.Dtos.Security
{
    public class ModuleDto : BaseDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Order { get; set; }
    }
}