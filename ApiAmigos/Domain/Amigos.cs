using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAmigos.Models
{
    public class Amigos
    {
        public Guid Id { get; set; }
        public string nome { get; set; }
        public string sobrenome { get; set; }
        public string urlFoto { get; set; }
        public string email { get; set; }
        public string telefone { get; set; }
        public DateTime dataAniversario { get; set; }
        public List<RelacionamentoAmigos> RelacionamentoAmigos { get; set; }

    }

}
