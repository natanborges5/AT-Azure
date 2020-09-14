using System;
using System.Collections.Generic;

namespace ApiPaises.Domain
{
    public class Paises
    {
        public Guid Id { get; set; }
        public string nome { get; set; }
        public string urlFoto { get; set; }
        public List<Estados> Estados { get; set; }
    }
}
