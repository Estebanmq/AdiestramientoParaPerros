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

        /// <summary>
        ///     Set que almacena todas las citas de la bdd
        /// </summary>
        public DbSet<Cita> Citas { get; set; }

        /// <summary>
        ///     Set que almacena todas las consultas de la bdd
        /// </summary>
        public DbSet<Consulta> Consultas { get; set; }

        /// <summary>
        ///     Set que almacena todos los estados de la bdd
        /// </summary>
        public DbSet<Estado> Estados { get; set; }

        /// <summary>
        ///     Set que almacena todos los usuarios de las bdd
        /// </summary>
        public DbSet<Usuario> Usuarios { get; set; }

        /// <summary>
        ///     Set que almacena todos los roles de la bdd
        /// </summary>
        public DbSet<Rol> Roles { get; set; }
    }
}
