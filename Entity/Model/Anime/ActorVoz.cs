using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Entity.Model.Base;

namespace Entity.Model.Anime
{
    public class ActorVoz : BaseModel
    {
        public string? Nombre { get; set; }
        public string? Nacionalidad { get; set; }
        public ICollection<PersonajeVoz> PersonajeVoces { get; set; }
    }
}
