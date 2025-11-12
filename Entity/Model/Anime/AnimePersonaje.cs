using System.ComponentModel.DataAnnotations.Schema;

namespace Entity.Model.Anime
{
    public class AnimePersonaje
    {
        public int IdAnime { get; set; }
        public int IdPersonaje { get; set; }
        public string Papel { get; set; }
        public Anime Anime { get; set; }
        public Personaje Personaje { get; set; }
    }
}
