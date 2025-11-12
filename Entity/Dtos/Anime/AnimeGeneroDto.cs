using System.ComponentModel.DataAnnotations.Schema;
using Entity.Dtos.Base;
namespace Entity.Dtos.Anime
{
    public class AnimeGeneroDto : BaseDto
    {
        public int IdAnime { get; set; }
        public int IdGenero { get; set; }
    }
}
