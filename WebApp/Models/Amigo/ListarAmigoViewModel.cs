using Microsoft.AspNetCore.Http;
using System;

namespace WebApp.Models.Amigo
{
    public class ListarAmigoViewModel
    {
        public string Id { get; set; }
        public string nome { get; set; }
        public string sobrenome { get; set; }
        public string email { get; set; }
        public string telefone { get; set; }
        public DateTime dataAniversario { get; set; }
        public string urlFoto { get; set; }
    }
}
