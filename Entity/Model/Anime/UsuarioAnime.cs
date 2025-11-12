using System.ComponentModel.DataAnnotations.Schema;

using Entity.Model.Security;
using Entity.Model.Base;

namespace Entity.Model.Anime
{
    public class UsuarioAnime : BaseModel
    {
        public int IdUser { get; set; }
        public int IdAnime { get; set; }
        public int? Calificacion { get; set; }
        public string EstadoVisualizacion { get; set; }
        public User User { get; set; }
        public Animes Anime { get; set; }
    }
}
