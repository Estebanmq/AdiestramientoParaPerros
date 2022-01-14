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

        public DbSet<Cita>Citas { get; set; }

       
    }
}
