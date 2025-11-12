using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Entity.Model.Base;

namespace Entity.Model.Anime
{
    public class Personaje : BaseModel
    {
        public string Nombre { get; set; }
        public string Rol { get; set; }
        public string Descripcion { get; set; }

        public ICollection<AnimePersonaje> AnimePersonajes { get; set; }
        public ICollection<PersonajeVoz> PersonajeVoces { get; set; }
    }
}
