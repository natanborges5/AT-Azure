using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiPaises.Resources.PaisesResource
{
    public class PaisesRequest
    {
        public string nome { get; set; }

        public string urlFoto { get; set; }

        public List<string> Erros()
        {
            return new List<string>();
        }
    }

}
