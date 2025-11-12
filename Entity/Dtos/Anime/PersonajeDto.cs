using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Entity.Dtos.Base;

namespace Entity.Dtos.Anime
{
    public class PersonajeDto : BaseDto
    {
        public string Nombre { get; set; }
        public string Rol { get; set; }
        public string Descripcion { get; set; }
    }
}
