using System.ComponentModel.DataAnnotations.Schema;
using Entity.Model.Security;

namespace Entity.Model.Anime
{
    public class UsuarioAnime
    {
        public int IdUser { get; set; }
        public int IdAnime { get; set; }
        public int? Calificacion { get; set; }
        public string EstadoVisualizacion { get; set; }
        public User User { get; set; }
        public Anime Anime { get; set; }
    }
}
