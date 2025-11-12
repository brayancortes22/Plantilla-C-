using System.ComponentModel.DataAnnotations.Schema;
using Entity.Model.Base;

namespace Entity.Model.Anime
{
    public class AnimeGenero : BaseModel
    {
        public int IdAnime { get; set; }
        public int IdGenero { get; set; }
        public Animes Anime { get; set; }
        public Genero Genero { get; set; }
    }
}
