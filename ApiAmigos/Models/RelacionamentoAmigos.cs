using System;

namespace ApiAmigos.Models
{
    public class RelacionamentoAmigos
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string sobrenome { get; set; }
        public string email { get; set; }
        public string telefone { get; set; }
        public DateTime dataAniversario { get; set; }
    }

}
