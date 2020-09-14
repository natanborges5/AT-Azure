using System;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiAmigos.Resources.AmigoResource
{
        public class AmigosRequest
        {
            public string nome { get; set; }
            public string sobrenome { get; set; }
            public string email { get; set; }
            public string telefone { get; set; }
            public string urlFoto { get; set; }

            public DateTime dataAniversario { get; set; }

            public List<string> Erros()
            {
                return new List<string>();
            }
        }
}
