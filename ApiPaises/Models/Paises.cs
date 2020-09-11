using System;
using System.Collections.Generic;

namespace ApiPaises.Models
{
    public class Paises
    {
        public Guid id { get; set; }
        public string nome { get; set; }
        public string fotoBandeiraPais { get; set; }
        public List<Estados> Estados { get; set; }
    }
}
