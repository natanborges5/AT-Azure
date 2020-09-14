using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models.Paises
{
    public class CriarPaisViewModel
    {
        public string nome { get; set; }
        public IFormFile fotoPais { get; set; }
        public string urlFoto { get; set; }
        public List<string> Erros { get; set; } = new List<string>();
    }
}
