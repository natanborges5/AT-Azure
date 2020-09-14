using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ApiPaises.Resources.PaisesResource;
using ApiPaises.Domain;

namespace ApiPaises.Data
{
    public class ApiPaisesContext : DbContext
    {
        public ApiPaisesContext (DbContextOptions<ApiPaisesContext> options)
            : base(options)
        {
        }

        public DbSet<Paises> Paises { get; set; }
        public DbSet<Estados> Estados { get; set; }
    }
}
