using System;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiPaises.Resources.PaisesResource
{
    public class PaisesResponse
    {
        public Guid Id { get; set; }
        public string nome { get; set; }
        public string urlFoto { get; set; }
    }

}
