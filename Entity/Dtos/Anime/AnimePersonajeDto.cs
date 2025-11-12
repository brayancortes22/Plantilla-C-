using System.ComponentModel.DataAnnotations.Schema;
using Entity.Dtos.Base;
namespace Entity.Dtos.Anime
{
    public class AnimePersonajeDto : BaseDto
    {
        public int IdAnime { get; set; }
        public int IdPersonaje { get; set; }
        public string Papel { get; set; }
    }
}
