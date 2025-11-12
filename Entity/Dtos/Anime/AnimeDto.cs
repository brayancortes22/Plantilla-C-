using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Entity.Dtos.Base;
namespace Entity.Dtos.Anime
{
    public class AnimeDto : BaseDto
    {
        public string Titulo { get; set; }
        public string Sinopsis { get; set; }
        public DateTime? FechaEmision { get; set; }
        public string Estado { get; set; }
        public int? IdEstudio { get; set; }

    }
}
