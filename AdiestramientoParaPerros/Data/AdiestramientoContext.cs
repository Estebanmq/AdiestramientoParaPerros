using AdiestramientoParaPerros.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdiestramientoParaPerros.Data
{
    public class AdiestramientoContext : DbContext
    {
        public AdiestramientoContext(DbContextOptions<AdiestramientoContext> options ) : base(options) { } 

        //Set que almacena todas las citas de la bdd
        public DbSet<Cita> Citas { get; set; }

        //Set que almacena todas las consultas de la bdd
        public DbSet<Consulta> Consultas { get; set; }

        //Set que almacena todos los estados de la bdd
        public DbSet<Estado> Estados { get; set; }

        //Set que almacena todos los usuarios de las bdd
        public DbSet<Usuario> Usuarios { get; set; }

        //Set que almacena todos los roles de la bdd
        public DbSet<Rol> Roles { get; set; }
    }
}
