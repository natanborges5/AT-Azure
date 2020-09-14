using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models.Amigo
{
    public class CriarAmigoViewModel
    {
        public string nome { get; set; }
        public string sobrenome { get; set; }
        public string email { get; set; }
        public string telefone { get; set; }
        public DateTime dataAniversario { get; set; }
        public IFormFile fotoAmigo { get; set; }
        public string urlFoto { get; set; }
        public List<string> Erros { get; set; } = new List<string>();
    }
}
