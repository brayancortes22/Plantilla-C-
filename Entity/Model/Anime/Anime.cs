using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Entity.Model.Base;

namespace Entity.Model.Anime
{
    public class Animes : BaseModel
    {
        public string Titulo { get; set; }
        public string Sinopsis { get; set; }
        public DateTime? FechaEmision { get; set; }
        public string Estado { get; set; }
        public int? IdEstudio { get; set; }
        public Estudio Estudio { get; set; }

        public ICollection<AnimeGenero> AnimeGeneros { get; set; }
        public ICollection<AnimePersonaje> AnimePersonajes { get; set; }
        public ICollection<UsuarioAnime> UsuarioAnimes { get; set; }
    }
}
