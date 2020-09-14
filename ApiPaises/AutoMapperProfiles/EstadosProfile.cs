using ApiPaises.Domain;
using ApiPaises.Resources.PaisesResource;
using AutoMapper;

namespace ApiPaises.AutoMapperProfiles
{
    public class EstadosProfile : Profile
    {
        public EstadosProfile()
        {
            CreateMap<Estados, EstadosResponse>();
            CreateMap<EstadosRequest, Estados>();
        }
    }
}
