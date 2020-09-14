using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ApiAmigos.Models;

namespace ApiAmigos.Data
{
    public class ApiAmigosContext : DbContext
    {
        public ApiAmigosContext (DbContextOptions<ApiAmigosContext> options)
            : base(options)
        {
        }

        public DbSet<Amigos> Amigos { get; set; }
    }
}
