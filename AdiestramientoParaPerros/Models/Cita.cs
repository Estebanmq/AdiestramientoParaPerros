using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AdiestramientoParaPerros.Models
{   
    [Table("CITAS")]
    public class Cita
    {
        [Key]
        [Column("IDCITA")]
        public int IdCita { get; set; }

        [Column("FECHACITA")]
        public DateTime FechaCita { get; set; }

        [Column("TELEFONOCONTACTO")]
        public int TelefonoContacto { get; set; }

        [Column("NOMBREPERRO")]
        public String NombrePerro { get; set; }

        [Column("RAZAPERRO")]
        public String RazaPerro { get; set; }

        [Column("MOTIVO")]
        public String MotivoCita { get; set; }

        [Column("OBJETIVO")]
        public String ObjetivoCita { get; set; }

        [Column("IDCLIENTE")]
        public int IdCliente { get; set; }

        //[Column("IDEMPLEADO")]
        //public int IdEmpleado { get; set; }
    }
}
