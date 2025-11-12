using Entity.Dtos.Base;
namespace Entity.Dtos.Security
{
    public class FormDto : BaseDto
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public string Icon { get; set; }
    }
}