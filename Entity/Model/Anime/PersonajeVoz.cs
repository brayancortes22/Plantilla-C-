using System.ComponentModel.DataAnnotations.Schema;
using Entity.Model.Base;
namespace Entity.Model.Anime
{
    public class PersonajeVoz : BaseModel
    {
        public int IdActorVoz { get; set; }
        public int IdPersonaje { get; set; }
        public string Idioma { get; set; }
        public Personaje Personaje { get; set; }
        public ActorVoz ActorVoz { get; set; }
    }
}
