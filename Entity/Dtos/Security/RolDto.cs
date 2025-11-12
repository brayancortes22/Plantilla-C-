using Entity.Dtos.Base;
namespace Entity.Dtos.Security
{
    public class RolDto : BaseDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsSystem { get; set; }
    }
}