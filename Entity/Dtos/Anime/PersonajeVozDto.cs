using System.ComponentModel.DataAnnotations.Schema;
using Entity.Dtos.Base;
namespace Entity.Dtos.Anime
{
    public class PersonajeVozDto : BaseDto
    {
        public int IdActorVoz { get; set; }
        public int IdPersonaje { get; set; }
        public string Idioma { get; set; }
    }
}
