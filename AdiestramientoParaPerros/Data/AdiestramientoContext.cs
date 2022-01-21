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

        //Set que almacena todas las citas de la base de datos
        public DbSet<Cita> Citas { get; set; }

        //Set que almacena todas las consultas de la base de datos
        public DbSet<Consulta> Consultas { get; set; }

        //Set que almacena todos los empleados de la base de datos
        public DbSet<Empleado> Empleados { get; set; }

        //Set que almacena todos los estados de las consultas
        public DbSet<Estado> Estados { get; set; }
    }
}
