using AutoMapper;
using Entity.Model.Anime;
using Entity.Dtos.Anime;

namespace Utilities.Mappers.Profiles.Anime
{
    public class ActorVozProfile : Profile
    {
        public ActorVozProfile()
        {
            CreateMap<ActorVoz, ActorVozDto>().ReverseMap();
        }
    }
}
