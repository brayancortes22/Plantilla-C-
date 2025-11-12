using AutoMapper;
using Entity.Model.Anime;
using Entity.Dtos.Anime;

namespace Utilities.Mappers.Profiles.Anime
{
    public class EstudioProfile : Profile
    {
        public EstudioProfile()
        {
            CreateMap<Estudio, EstudioDto>().ReverseMap();
        }
    }
}
