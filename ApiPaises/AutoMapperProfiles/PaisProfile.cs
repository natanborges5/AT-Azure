using ApiPaises.Resources.PaisesResource;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiPaises.AutoMapperProfiles
{
    public class PaisProfile : Profile
    {
        public PaisProfile()
        {
            CreateMap<Paises, PaisesResponse>();
            CreateMap<PaisesRequest, Paises>();
        }
    }
}
