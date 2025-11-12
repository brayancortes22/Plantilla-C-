using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Entity.Dtos.Base;

namespace Entity.Dtos.Anime
{
    public class EstudioDto : BaseDto
    {
        public string Nombre { get; set; }
        public string Pais { get; set; }
        public int? Fundacion { get; set; }
    }
}
