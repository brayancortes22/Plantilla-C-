using System.ComponentModel.DataAnnotations.Schema;
using Entity.Dtos.Base;

namespace Entity.Dtos.Anime
{
    public class UsuarioAnimeDto : BaseDto
    {
        public int IdUser { get; set; }
        public int IdAnime { get; set; }
        public int? Calificacion { get; set; }
        public string EstadoVisualizacion { get; set; }
    }
}
