using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Entity.Model.Base;

namespace Entity.Model.Anime
{
    public class Estudio : BaseModel
    {
        public string Nombre { get; set; }
        public string Pais { get; set; }
        public int? Fundacion { get; set; }
        public ICollection<Anime> Animes { get; set; }
    }
}
