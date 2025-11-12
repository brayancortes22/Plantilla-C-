using System.ComponentModel.DataAnnotations.Schema;

using Entity.Model.Base;
namespace Entity.Model.Anime
{
    public class AnimePersonaje : BaseModel
    {
        public int IdAnime { get; set; }
        public int IdPersonaje { get; set; }
        public string Papel { get; set; }
        public Animes Anime { get; set; }
        public Personaje Personaje { get; set; }
    }
}
