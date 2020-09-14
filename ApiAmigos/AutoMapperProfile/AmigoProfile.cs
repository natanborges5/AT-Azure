using ApiAmigos.Models;
using AutoMapper;
using ApiAmigos.Resources.AmigoResource;

namespace ApiPaises.AutoMapperProfiles
{
    public class AmigoProfile : Profile
    {
        public AmigoProfile()
        {
            CreateMap<Amigos, AmigosResponse>();
            CreateMap<AmigosRequest, Amigos>();
        }
    }
}
