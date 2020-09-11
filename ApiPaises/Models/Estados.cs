using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiPaises.Models
{
    public class Estados
    {
        public string nome { get; set; }
        public string fotoBandeiraEstado { get; set; }
        public Guid paisId { get; set; }
    }
}
