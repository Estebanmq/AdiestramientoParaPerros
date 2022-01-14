using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AdiestramientoParaPerros.Models
{
    [Table("EMPLEADOS")]
    public class Empleado
    {
        [Key]
        [Column("IDEMPLEADO")]
        public int IdEmpleado { get; set; }

        public Usuario Usuario { get; set; }

        [Column("CORREO")]
        public String Correo { get; set; }

        [Column("NVLPERMISO")]
        public int NvlPermiso { get; set; } 
    }
}
