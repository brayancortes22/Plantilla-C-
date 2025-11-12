using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Entity.Model.Base;

namespace Entity.Model.Anime
{
    public class Genero : BaseModel
    {
        public string Nombre { get; set; }
        public ICollection<AnimeGenero> AnimeGeneros { get; set; }
    }
}
