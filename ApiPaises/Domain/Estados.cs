using System;

namespace ApiPaises.Domain
{
    public class Estados
    {
        public int Id { get; set; }
        public string nomeEstado { get; set; }
        public string fotoEstado { get; set; }
        public Guid paisId { get; set; }

    }
}
